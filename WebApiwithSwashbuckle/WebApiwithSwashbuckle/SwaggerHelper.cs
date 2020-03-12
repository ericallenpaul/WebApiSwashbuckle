using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiwithSwashbuckle
{
    public class SwaggerHelper
    {
        /// <summary>Configures the swagger gen.</summary>
        /// <param name="swaggerGenOptions">The swagger gen options.</param>
        public static void ConfigureSwaggerGen(SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "WebApiSwashbuckle",
                Version = $"v1",
                Description = "An example of using .net core api with swashbuckle."
            });

            swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            string filePath = Path.Combine(AppContext.BaseDirectory, "WebApiwithSwashbuckle.xml");
            swaggerGenOptions.IncludeXmlComments(filePath);
            filePath = Path.Combine(AppContext.BaseDirectory, "WebAPISwashbuckle.Models.xml");
            swaggerGenOptions.IncludeXmlComments(filePath);

        }

        /// <summary>Configures the swagger.</summary>
        /// <param name="swaggerOptions">The swagger options.</param>
        public static void ConfigureSwagger(SwaggerOptions swaggerOptions)
        {
            swaggerOptions.RouteTemplate = "api-docs/{documentName}/swagger.json";
        }

        /// <summary>Configures the swagger UI.</summary>
        /// <param name="swaggerUIOptions">The swagger UI options.</param>
        public static void ConfigureSwaggerUI(SwaggerUIOptions swaggerUIOptions)
        {
            swaggerUIOptions.SwaggerEndpoint($"/api-docs/v1/swagger.json", $"v1 Docs");
            swaggerUIOptions.RoutePrefix = "api-docs";
        }
    }
}
