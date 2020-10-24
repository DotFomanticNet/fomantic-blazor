///-------------------------------------------------------------------------------------------------
// file:	Helpers\IconListHelpers.cs
//
// summary:	Implements the icon list helpers class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   An icon list helpers. </summary>
    static class IconListHelpers
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   An IconList extension method that converts an icon to the CSS class. </summary>
        ///
        /// <param name="icon"> The icon to act on. </param>
        ///
        /// <returns>   Icon as a string. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToCssClass(this IconList icon)
        {
            return Regex.Replace(icon.ToString(), @"(([A-Z]))", " $1").Trim().ToLower();
        }
    }
}
