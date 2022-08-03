using System.Configuration;
using Microsoft.Extensions.Configuration;
using Task4_userAPI.CustomExceptionMiddleware;

namespace Task4_userAPI
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, userRepo>();
            services.AddScoped<IpostRepo, postRepo>();
     


        }

        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
