using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    /// <summary>
    /// Base interface for all fomantic component can be disabled
    /// </summary>
    public interface IFomanticComponentCanBeUnselectable : IFomanticComponentWithClass
    {
        /// <summary>
        /// class given to the component to make content text unselectable
        /// </summary>
        const string UnselectableClass = "unselectable";

        /// <summary>
        /// Determine if the content text should be selectable or not
        /// </summary>
        [Parameter]
        bool IsUnselectable { get; set; }
    }
}
