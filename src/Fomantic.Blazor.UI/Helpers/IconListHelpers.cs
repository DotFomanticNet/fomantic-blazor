
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    static class IconListHelpers
    {
        public static string ToCssClass(this IconList icon)
        {
            return Regex.Replace(icon.ToString(), @"(([A-Z]))", " $1").Trim().ToLower();
        }
    }
}
