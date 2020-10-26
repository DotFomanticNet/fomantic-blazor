using System.Threading.Tasks;

namespace Fomantic.Blazor.UI.Features
{
    class AnimateableFomanticComponentFeature : UIFeatureDefinition<IAnimateableFomanticComponent>
    {
        public async override ValueTask<bool> OnAfterFirstRender(IAnimateableFomanticComponent component)
        {
            component.Extensions.Add(new FomanticComponentAnimator<IAnimateableFomanticComponent>(component));
            return await base.OnAfterFirstRender(component);
        }


    }
}
