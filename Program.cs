using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using ApiForPsycho.Models;
using ApiForPsycho.Controllers;
using Microsoft.Extensions.Options;

namespace ApiForPsycho
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors();
            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "bla-bla-bla", Version = "v1" });
                option.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
                option.DocInclusionPredicate((name, api) => true);
            });


            var app = builder.Build();

            app.MapControllers();
            app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller = Home}/{action=Index}/{id?}");

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.Run();
        }
    }
    
}