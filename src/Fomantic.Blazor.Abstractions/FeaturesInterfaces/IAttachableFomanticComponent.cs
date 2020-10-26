///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IAttachableFomanticComponent.cs
//
// summary:	Declares the IAttachableFomanticComponent interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all fomantic component can be attached to other content on a page.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IAttachableFomanticComponent : IFomanticComponentWithClass
    {
       

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine if the comonent should be attached to other content on a page. </summary>
        ///
        /// <value> The attaching. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        AttachingDirection? Attaching { get; set; }


        
    }
}
