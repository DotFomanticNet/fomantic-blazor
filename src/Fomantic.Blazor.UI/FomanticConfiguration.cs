///-------------------------------------------------------------------------------------------------
/// <file>  Fomantic.Blazor.UI\FomanticConfiguration.cs </file>
///
/// <copyright file="FomanticConfiguration.cs" company="MyCompany.com">
/// Copyright (c) 2020 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>   Implements the fomantic configuration class. </summary>
///-------------------------------------------------------------------------------------------------


using Fomantic.Blazor.UI.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   A fomantic startup configuration. </summary>
    public static class FomanticConfiguration
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Call at startup to register fomantic UI services. </summary>
        ///
        /// <param name="services"> The services to act on. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void UseFomantic(this IServiceCollection services)
        {
            services.AddSingleton(typeof(FeaturesService));
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Call at startup to register fomantic UI services . </summary>
        ///
        /// <param name="builder">  The builder to act on. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void UseFomantic(this WebAssemblyHostBuilder builder)
        {
            builder.Services.UseFomantic();
        }
    }
}
