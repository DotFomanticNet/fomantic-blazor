///-------------------------------------------------------------------------------------------------
// file:	FomanticBase\FomanticComponentWithContentBase.cs
//
// summary:	Implements the fomantic component with content base class
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;


namespace Fomantic.Blazor.UI
{
    /// <summary>   Base class for all Fomantic Component. </summary>
    public abstract partial class FomanticComponentWithContentBase : FomanticComponentBase, IFomanticComponentWithContent

    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Content of the component.   </summary>
        ///
        /// <value> The child content. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public RenderFragment ChildContent { get; set; }



    }
}
