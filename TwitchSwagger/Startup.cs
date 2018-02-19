using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace TwitchSwagger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvcCore()
                .AddApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "TwitchApi", Version = "v1" });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "TwitchSwagger.xml");
                if (System.IO.File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
                               
                c.AddSecurityDefinition("TwitchApi", new OAuth2Scheme
                {
                    AuthorizationUrl = "https://api.twitch.tv/kraken/oauth2/authorize",
                    Flow = "implicit",
                    Scopes = new Dictionary<string, string>{
                        { "openid","openid" },
                        { "clips:edit", "Create clips" }
                    },
                    TokenUrl= "https://api.twitch.tv/api/oauth2/token"
                });

                c.DocumentFilter<AddScheme>("https");
                c.DocumentFilter<SetHost>("api.twitch.tv/helix");
                c.DocumentFilter<OrderPaths>();

                c.OperationFilter<AuthorizedOperation>("TwitchApi");
                c.OperationFilter<EnumParametersAsStrings>();
                c.OperationFilter<RequiredParameters>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();            
            
            app.UseSwagger();

            var clientId = Configuration.GetValue<string>("ClientId");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Twitch Api");
                c.ConfigureOAuth2(clientId, null, "", "");
            });
        }
    }
    public class SetHost : IDocumentFilter
    {
        readonly string host;
        public SetHost(string host)
        {
            this.host = host;
        }
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {            
            swaggerDoc.Host = host;                                    
        }
    }

    public class OrderPaths : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths = swaggerDoc
                .Paths
                .OrderBy(_ => _.Key)
                .ToDictionary(_ => _.Key, _ => _.Value);
        }
    }
    public class AddScheme : IDocumentFilter
    {
        readonly string scheme;
        public AddScheme(string scheme)
        {
            this.scheme = scheme;
        }
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if(swaggerDoc.Schemes == null)
            {
                swaggerDoc.Schemes = new List<string>();
            }
            if (!swaggerDoc.Schemes.Contains(scheme))
            {
                swaggerDoc.Schemes.Add(scheme);
            }
        }
    }

    public class AuthorizedOperation : IOperationFilter
    {
        readonly string securityDefinitionName;
        public AuthorizedOperation(string securityDefinitionName)
        {
            this.securityDefinitionName = securityDefinitionName;
        }
        public void Apply(Operation operation, OperationFilterContext context)
        {            
            if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
            {
                if (controllerDescriptor.ControllerTypeInfo.GetCustomAttribute(typeof(AuthorizeAttribute)) != null
                    || controllerDescriptor.MethodInfo.GetCustomAttribute(typeof(AuthorizeAttribute)) != null)
                {                    
                    operation.Security = new List<IDictionary<string, IEnumerable<string>>>();
                    operation.Security.Add(
                        new Dictionary<string, IEnumerable<string>>
                        {
                            {securityDefinitionName, new string[]{ } }
                        }
                    );
                }

            }
        }
    }

    public class EnumParametersAsStrings : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) return;
            foreach(var param in operation.Parameters)
            {
                if(param is PartialSchema paramSchema && paramSchema.Enum != null)
                {
                    var enumType = paramSchema.Enum.First().GetType();
                    paramSchema.Enum = new List<object>(Enum.GetNames(enumType));
                    paramSchema.Type = "string";
                    paramSchema.Format = null;
                }
            }            
        }
    }
    public class RequiredParameters : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {            
            var parameters = context
                .ApiDescription
                .ParameterDescriptions
                .Select(_ => _.ParameterDescriptor)
                .Where(_ => _ is ControllerParameterDescriptor)
                .Cast<ControllerParameterDescriptor>();

            foreach (var paramDesc in parameters)
            {
                var required = paramDesc.ParameterInfo.GetCustomAttribute<RequiredAttribute>();
                if(required != null)
                {
                    var operationParam = operation.Parameters.FirstOrDefault(_ => _.Name == paramDesc.Name);
                    if(operationParam != null)
                    {
                        operationParam.Required = true;                        
                    }                    
                }
            }

            return;
        }
    }
}
