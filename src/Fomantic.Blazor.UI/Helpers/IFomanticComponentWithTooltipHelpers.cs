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
        internal static T AddTooltip<T>(this T component) where T : IFomanticComponentWithTooltip
        {

            if (component.HasTooltip())
            {
                component.AddOrUpdateAttribute("data-tooltip", component.TooltipText);
                if (component.IsTooltipInverted.HasValue && component.IsTooltipInverted.Value)
                {
                    component.AddOrUpdateAttribute("data-inverted", "");
                }
                else
                {
                    if (component is IFomanticComponentWithInvertedStyle && (component as IFomanticComponentWithInvertedStyle).IsInverted)
                    {
                        component.AddOrUpdateAttribute("data-inverted", "");
                    }

                }
                component.AddOrUpdateAttribute("data-position", IFomanticComponentWithTooltip.ToClass(component.TooltipPosition));
                string variation = "";
                variation += " " + IFomanticComponentWithSize.ToClass(component.TooltipSize);
                if (component.IsTooltipBasicFormat)
                {
                    variation += " basic";
                }
                component.AddOrUpdateAttribute("data-variation", variation);

            }
            else
            {
                component.RemoveAttribute("data-tooltip");
                component.RemoveAttribute("data-variation");
                component.RemoveAttribute("data-position");
            }
            return component;
        }
    }
}
