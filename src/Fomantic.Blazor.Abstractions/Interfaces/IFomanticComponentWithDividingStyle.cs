using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    /// <summary>
    /// Base interface for all fomantic component that can formatted to divide itself from the content below it
    /// </summary>
    public interface IFomanticComponentWithDividingStyle : IFomanticComponentWithClass
    {
        /// <summary>
        /// class given to the component to divide itself from the content below it
        /// </summary>
        const string DividingClass = "dividing";
        /// <summary>
        /// Determine if the component should formatted to divide itself from the content below it or not
        /// </summary>
        [Parameter]
        bool IsDividing { get; set; }
    }
}
