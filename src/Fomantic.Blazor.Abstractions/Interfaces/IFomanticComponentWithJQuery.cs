///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithJQuery.cs
//
// summary:	Declares the IFomanticComponentWithJQuery interface
///-------------------------------------------------------------------------------------------------

using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base interface for all fomantic component that can interop with jquery. </summary>
    public interface IFomanticComponentWithJQuery : IFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   JQuery JS Object Reference , Used to call jquery methods. </summary>
        ///
        /// <value> The j query element reference. </value>
        ///-------------------------------------------------------------------------------------------------

        public IJSObjectReference JQueryElementRef { get; internal set; }
    }
}
