///-------------------------------------------------------------------------------------------------
// file:	Animators\FomanticComponentAnimator.cs
//
// summary:	Implements the fomantic component animator class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Class responsibe for animating a <see cref="IFomanticComponent"/> </summary>
    ///
    /// <typeparam name="TFomanticComponent">   Type of the fomantic component. </typeparam>
    ///-------------------------------------------------------------------------------------------------

    public class FomanticComponentsAnimator<TFomanticComponent> : ElementReferenceFomanticAnimator where TFomanticComponent : IFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the components. </summary>
        ///
        /// <value> The components. </value>
        ///-------------------------------------------------------------------------------------------------

        public List<TFomanticComponent> Components { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Create An instant of Animator. </summary>
        ///
        /// <param name="component">    Fomantic component to animate. </param>
        ///-------------------------------------------------------------------------------------------------

        public FomanticComponentsAnimator(params TFomanticComponent[] component) : base(component?.FirstOrDefault()?.JsRuntime, component?.Select(d => d.RootElement)?.ToArray())
        {
            Components = component.ToList();
        }

        /// <inheritdoc/>
        public async override Task Animate(int interval = 200, params Tuple<TransitionAnimation, int>[] animations)
        {
            await base.Animate(interval, animations);
            foreach (var component in Components)
            {
                if (component is IVisibleFomanticComponent)
                {
                    (component as IVisibleFomanticComponent).IsHidden = !(component as IVisibleFomanticComponent).IsHidden;
                }

            }
        }
        /// <inheritdoc/>
        public async override Task Animate(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            await base.Animate(animation, duration, interval);
            foreach (var component in Components)
            {
                if (component is IVisibleFomanticComponent)
                {
                    (component as IVisibleFomanticComponent).IsHidden = !(component as IVisibleFomanticComponent).IsHidden;
                }

            }
        }

        /// <inheritdoc/>
        public async override Task AnimatedHide(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            await base.AnimatedHide(animation, duration, interval);
            foreach (var component in Components)
            {
                if (component is IVisibleFomanticComponent)
                {
                    (component as IVisibleFomanticComponent).IsHidden = true;
                }

            }
        }
        /// <inheritdoc/>
        public async override Task AnimatedShow(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            await base.AnimatedShow(animation, duration, interval);
            foreach (var component in Components)
            {
                if (component is IVisibleFomanticComponent)
                {
                    (component as IVisibleFomanticComponent).IsHidden = false;
                }

            }
        }


    }

}

