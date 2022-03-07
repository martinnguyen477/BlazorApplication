using BlazorApplication.API.Data;
using BlazorApplication.API.DataContext;
using BlazorApplication.API.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace BlazorApplication.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDbContext<TodoDbContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<TodoListContextSeed>>();
                new TodoListContextSeed().SeedAsync(context, logger).Wait();
            });
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
