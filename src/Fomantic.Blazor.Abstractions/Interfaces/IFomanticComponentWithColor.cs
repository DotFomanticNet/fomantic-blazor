///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithColor.cs
//
// summary:	Declares the IFomanticComponentWithColor interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that can be colored based on Fomantic
    /// standard colors.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticComponentWithColor : IFomanticComponentWithClass
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine how the component should be colored. </summary>
        ///
        /// <value> The color. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        Color? Color { get; set; }

      
    }
}


