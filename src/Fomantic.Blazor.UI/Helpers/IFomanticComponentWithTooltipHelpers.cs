using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    static class IFomanticComponentWithTooltipHelpers
    {
        internal static bool HasTooltip<T>(this T component) where T : IFomanticComponentWithTooltip
        {
            return !component.IsTooltipHidden && !string.IsNullOrEmpty(component.TooltipText);
        }
     
    }
}
