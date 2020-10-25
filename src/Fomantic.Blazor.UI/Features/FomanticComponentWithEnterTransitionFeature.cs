using System.Threading.Tasks;

namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithEnterTransitionFeature : UIFeatureDefinition<IFomanticComponentWithEnterTransition>
    {
        public async override ValueTask<bool> OnAfterFirstRender(IFomanticComponentWithEnterTransition component)
        {

            //if (EnterTransition.HasValue )//to do add paramter
            //{
            //    ViewportVisibility.Apply();
            //    OnTopVisibilityEvent += async d =>
            //    {
            //        if (!isEnterAnimationPlayed)
            //        {
            //            await Animator.AnimatedShow(EnterTransition.Value, EnterTransitionDuration);
            //            isEnterAnimationPlayed = true;
            //        }
            //    };
            //}
            //else 
            if (component.EnterTransition.HasValue)
            {
                if (!component.IsEnterAnimationDone)
                {
                    await component.Animator.AnimatedShow(component.EnterTransition.Value, component.EnterTransitionDuration);
                    component.IsEnterAnimationDone = true;
                }

            }
            return false;
        }
        public async override ValueTask OnInitialized(IFomanticComponentWithEnterTransition component)
        {
            if (component.EnterTransition.HasValue)
            {
                component.IsHidden = true;
            }
        }
    }

}
