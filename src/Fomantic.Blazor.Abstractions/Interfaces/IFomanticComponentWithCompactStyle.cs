///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithCompactStyle.cs
//
// summary:	Declares the IFomanticComponentWithCompactStyle interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{

    /// <summary>   Base interface for all fomantic component can be compact. </summary>
    public interface IFomanticComponentWithCompactStyle : IFomanticComponentWithClass
    {
      
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine if the component should be compact or not. </summary>
        ///
        /// <value> True if this  is compact, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        bool IsCompact { get; set; }
    }
}
