using System.Threading.Tasks;

namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithTooltipFeature : UIFeatureDefinition<IFomanticComponentWithTooltip>
    {
        public async override ValueTask<bool> OnAfterEachRender(IFomanticComponentWithTooltip component)
        {
            bool hasChanged = false;
            if (component.HasTooltip())
            {
                component.AddOrUpdateAttribute("data-tooltip", component.TooltipText, ref hasChanged);
                if (component.IsTooltipInverted.HasValue && component.IsTooltipInverted.Value)
                {
                    component.AddOrUpdateAttribute("data-inverted", "", ref hasChanged);
                }
                else
                {
                    if (component is IFomanticComponentWithInvertedStyle && (component as IFomanticComponentWithInvertedStyle).IsInverted)
                    {
                        component.AddOrUpdateAttribute("data-inverted", "", ref hasChanged);
                    }

                }
                component.AddOrUpdateAttribute("data-position", IFomanticComponentWithTooltip.ToClass(component.TooltipPosition), ref hasChanged);
                string variation = "";
                variation += " " + FomanticComponentWithSizeFeature.ToClass(component.TooltipSize);
                if (component.IsTooltipBasicFormat)
                {
                    variation += " basic";
                }
                component.AddOrUpdateAttribute("data-variation", variation, ref hasChanged);

            }
            else
            {
                component.RemoveAttribute("data-tooltip");
                component.RemoveAttribute("data-variation");
                component.RemoveAttribute("data-position");
            }
            return hasChanged;
        }
    }

}
