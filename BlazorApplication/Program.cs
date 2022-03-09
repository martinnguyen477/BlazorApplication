using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApplication.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient<ITaskClientAPI, TaskClientAPI>();
            builder.Services.AddTransient<IUserClientAPI, UserClientAPI>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

            await builder.Build().RunAsync();
        }
    }
}
