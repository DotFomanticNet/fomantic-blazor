///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithInvertedStyle.cs
//
// summary:	Declares the IFomanticComponentWithInvertedStyle interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{

    /// <summary>   Base interface for all fomantic component that can invert its color. </summary>
    public interface IFomanticComponentWithInvertedStyle : IFomanticComponentWithClass
    {
       
      

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine if the component should has inverted color or not. </summary>
        ///
        /// <value> True if this  is inverted, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        bool IsInverted { get; set; }
    }
}
