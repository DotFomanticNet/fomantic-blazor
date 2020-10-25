using Fomantic.Blazor.Docs.Helpers;
using Fomantic.Blazor.UI;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.Docs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.UseFomantic();
            DocumenationExtensions.Client = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

            await builder.Build().RunAsync();
        }
    }
}
