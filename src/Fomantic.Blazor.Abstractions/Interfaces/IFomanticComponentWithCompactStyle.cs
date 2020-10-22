using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{

    /// <summary>
    /// Base interface for all fomantic component can be compact 
    /// </summary>
    public interface IFomanticComponentWithCompactStyle : IFomanticComponentWithClass
    {
        /// <summary>
        /// class given to make component compact
        /// </summary>
        const string CompactClass = "compact";

        /// <summary>
        /// Determine if the component should be compact or not
        /// </summary>
        [Parameter]
        bool IsCompact { get; set; }
    }
}
