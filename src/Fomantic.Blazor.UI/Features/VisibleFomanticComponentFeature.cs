using System.Threading.Tasks;

namespace Fomantic.Blazor.UI.Features
{
    class VisibleFomanticComponentFeature : UIFeatureDefinition<IVisibleFomanticComponent>
    {
        public override ValueTask OnInitialized(IVisibleFomanticComponent component)
        {
            var viewportVisibility = new ViewportVisibility(component) as IViewportVisibility;
            component.Extensions.Add(viewportVisibility);
            return base.OnInitialized(component);
        }
        public override ValueTask<bool> OnAfterFirstRender(IVisibleFomanticComponent component)
        {



            //(component.ViewportVisibility as ViewportVisibility).Apply();


            return base.OnAfterFirstRender(component);
        }

        /// <summary>   class given to the component to invert its color. </summary>
        const string HiddenClass = "transition hidden";

        public override string ProvideCssClass(IVisibleFomanticComponent component)
        {
            if (component.IsHidden)
            {
                return HiddenClass;
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
