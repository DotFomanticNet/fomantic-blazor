using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    /// <summary>
    /// Base interface for all fomantic component can be fitted 
    /// </summary>
    public interface IFomanticComponentWithFittedStyle : IFomanticComponentWithClass
    {
        /// <summary>
        /// class given to make component fitted
        /// </summary>
        const string FittedClass = "fitted";

        /// <summary>
        /// Determine if the component should be fitted without any space to the left or right of it.
        /// </summary>
        [Parameter]
        bool IsFitted { get; set; }
    }
}
