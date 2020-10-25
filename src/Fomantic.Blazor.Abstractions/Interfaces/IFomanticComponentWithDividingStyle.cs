///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithDividingStyle.cs
//
// summary:	Declares the IFomanticComponentWithDividingStyle interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all fomantic component that can formatted to divide itself from the
    /// content below it.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticComponentWithDividingStyle : IFomanticComponentWithClass
    {
      

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Determine if the component should formatted to divide itself from the content below it or not.
        /// </summary>
        ///
        /// <value> True if this  is dividing, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        bool IsDividing { get; set; }
    }
}
