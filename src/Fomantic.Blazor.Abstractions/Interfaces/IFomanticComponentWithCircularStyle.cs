///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithCircularStyle.cs
//
// summary:	Declares the IFomanticComponentWithCircularStyle interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    /// <summary>   Base interface for all fomantic component can be circular. </summary>
    public interface IFomanticComponentWithCircularStyle : IFomanticComponentWithClass
    {
        /// <summary>   class given to make component circular. </summary>
        const string CircularClass = "circular";

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine if the component should be circular or not. </summary>
        ///
        /// <value> True if this  is circular, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsCircular { get; set; }
    }
}
