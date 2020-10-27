///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponent.cs
//
// summary:	Declares the IFomanticComponent interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base interface for all Fomantic Blazor Components that may have content inside it. </summary>
    public interface IFomanticComponentWithContent : IFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Content of the component.   </summary>
        ///
        /// <value> The child content. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        RenderFragment ChildContent { get; set; }
        // just an alias for ChildContent

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Content of the component.   </summary>
        ///
        /// <value> The content. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        RenderFragment Content { get { return ChildContent; } set { ChildContent = value; } }
    }
}
