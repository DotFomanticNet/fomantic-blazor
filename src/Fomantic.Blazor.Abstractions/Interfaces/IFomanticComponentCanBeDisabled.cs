///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentCanBeDisabled.cs
//
// summary:	Declares the IFomanticComponentCanBeDisabled interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    /// <summary>   Base interface for all fomantic component can be disabled. </summary>
    public interface IFomanticComponentCanBeDisabled : IFomanticComponentWithClass
    {
        /// <summary>   class given to disable component. </summary>
        const string DisabledClass = "disabled";

         ///-------------------------------------------------------------------------------------------------
         /// <summary>  Determine if the component should be disabled or not. </summary>
         ///
         /// <value>    True if this  is disabled, false if not. </value>
         ///-------------------------------------------------------------------------------------------------

        [Parameter]
         bool IsDisabled { get; set; } 
    }
}
