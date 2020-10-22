using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that can be colored based on Fomantic standard colors 
    /// </summary>
    public interface IFomanticComponentWithColor : IFomanticComponentWithClass
    {
        /// <summary>
        /// Determine how the component should be colored
        /// </summary>
        [Parameter]
        Color? Color { get; set; }

       
        /// <summary>
        /// Convert <see cref="Fomantic.Blazor.UI.Color"/> to given class
        /// </summary>
        /// <param name="color">Color Value</param>
        /// <returns>Given class from <paramref name="color"/> </returns>
        public static string ToClass(Color? color)
        {
            return color?.ToString()?.ToLower() ?? string.Empty;
        }
    }
}


