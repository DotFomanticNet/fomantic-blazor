///-------------------------------------------------------------------------------------------------
// file:	Helpers\IFomanticComponentWithTooltipHelpers.cs
//
// summary:	Declares the IFomanticComponentWithTooltipHelpers interface
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   A fomantic component with tooltip helpers. </summary>
    static class IFomanticComponentWithTooltipHelpers
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that query if 'component' has tooltip. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        ///
        /// <returns>   True if tooltip, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------

        internal static bool HasTooltip<T>(this T component) where T : IFomanticComponentWithTooltip
        {
            return !component.IsTooltipHidden && !string.IsNullOrEmpty(component.TooltipText);
        }
     
    }
}
