
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Base interface for all fomantic component that can interop with jquery
    /// </summary>
    public interface IFomanticComponentWithJQuery : IFomanticComponent
    {
        /// <summary>
        /// JQuery JS Object Reference , Used to call jquery methods
        /// </summary>
        public IJSObjectReference JQueryElementRef { get; }
    }
}
