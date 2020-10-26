///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithContentSpacing.cs
//
// summary:	Declares the IFomanticComponentWithContentSpacing interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all fomantic component that has space around its content.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticComponentWithContentSpacing : IFomanticComponentWithClass
    {
       
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine the space between  the component and its content. </summary>
        ///
        /// <value> The content space. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        ContentSpace? ContentSpace { get; set; }

       
    }
}


