///-------------------------------------------------------------------------------------------------
// file:	Animators\ElementReferenceAnimator.cs
//
// summary:	Implements the element reference animator class
///-------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Class responsibe for animating a <see cref="ElementReference"/> </summary>
    public class ElementReferenceFomanticAnimator : IFomanticAnimator
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Create An instant of Animator. </summary>
        ///
        /// <param name="jsRuntime">        used jsRuntime to call js animation function. </param>
        /// <param name="elementToAnimate"> <see cref="ElementReference"/> to animate. </param>
        ///-------------------------------------------------------------------------------------------------

        public ElementReferenceFomanticAnimator(IJSRuntime jsRuntime, params ElementReference[] elementToAnimate)
        {
            ElementToAnimate = elementToAnimate;
            JsRuntime = jsRuntime;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the element to animate. </summary>
        ///
        /// <value> The element to animate. </value>
        ///-------------------------------------------------------------------------------------------------

        private ElementReference[] ElementToAnimate { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the js runtime. </summary>
        ///
        /// <value> The js runtime. </value>
        ///-------------------------------------------------------------------------------------------------

        private IJSRuntime JsRuntime { get; }

        /// <inheritdoc/>
        [ComponentAction]
        public virtual async Task Animate(StaticAnimation animation, int duration = 800, int interval = 200)
        {
           
            if (ElementToAnimate.Count() > 1)
            {

                await JsRuntime.InvokeVoidAsync("window.animator.animateElements", ElementToAnimate, IFomanticAnimator.ToClass(animation), duration, interval);
            }
            else
            {
           
                await JsRuntime.InvokeVoidAsync("window.animator.animate", ElementToAnimate[0], IFomanticAnimator.ToClass(animation), duration);
            }

        }

        /// <inheritdoc/>
        [ComponentAction]
        public virtual async Task Animate(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            if (ElementToAnimate.Count() > 1)
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animateElements", ElementToAnimate, IFomanticAnimator.ToClass(animation), duration, interval);
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animate", ElementToAnimate[0], IFomanticAnimator.ToClass(animation), duration);
            }
        }


        /// <inheritdoc/>
        [ComponentAction]
        public virtual async Task AnimatedHide(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            if (ElementToAnimate.Count() > 1)
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animateElements", ElementToAnimate, IFomanticAnimator.ToClass(animation) + " out", duration, interval);
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animate", ElementToAnimate[0], IFomanticAnimator.ToClass(animation) + " out", duration);
            }
        }
        /// <inheritdoc/>
        [ComponentAction]
        public virtual async Task AnimatedShow(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            if (ElementToAnimate.Count() > 1)
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animateElements", ElementToAnimate, IFomanticAnimator.ToClass(animation) + " in", duration, interval);
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animate", ElementToAnimate[0], IFomanticAnimator.ToClass(animation) + " in", duration);
            }
        }

        /// <inheritdoc/>
        [ComponentAction]
        public virtual void QueueAnimatedHide(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            Task.Run(() => AnimatedHide(animation, duration, interval));
        }
        /// <inheritdoc/>
        [ComponentAction]
        public virtual void QueueAnimatedShow(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            Task.Run(() => AnimatedShow(animation, duration, interval));
        }
        /// <inheritdoc/>
        [ComponentAction]
        public virtual void QueueAnimation(StaticAnimation animation, int duration = 800, int interval = 200)
        {
            
            Task.Run(() => Animate(animation, duration, interval));
        }
        /// <inheritdoc/>
        [ComponentAction]
        public virtual void QueueAnimation(int interval = 200, params Tuple<StaticAnimation, int>[] animations)
        {
            Task.Run(() => Animate(interval, animations));
        }
        /// <inheritdoc/>
        [ComponentAction]
        public virtual void QueueAnimation(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            Task.Run(() => Animate(animation, duration, interval));
        }
        /// <inheritdoc/>
        [ComponentAction]
        public virtual void QueueAnimation(int interval = 200, params Tuple<TransitionAnimation, int>[] animations)
        {
            Task.Run(() => Animate(interval, animations));
        }


        /// <inheritdoc/>
        [ComponentAction]
        public virtual async Task Animate(int interval = 200, params Tuple<TransitionAnimation, int>[] animations)
        {
            if (ElementToAnimate.Count() > 1)
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animateElementsMultible", ElementToAnimate, animations.Select(d => new { animation = IFomanticAnimator.ToClass(d.Item1), duration = d.Item2 }), interval);
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animateMultible", ElementToAnimate[0], animations.Select(d => new { animation = IFomanticAnimator.ToClass(d.Item1), duration = d.Item2 }));
            }
        }


        /// <inheritdoc/>
        [ComponentAction]
        public virtual async Task Animate(int interval = 200, params Tuple<StaticAnimation, int>[] animations)
        {
            if (ElementToAnimate.Count() > 1)
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animateElementsMultible", ElementToAnimate, animations.Select(d => new { animation = IFomanticAnimator.ToClass(d.Item1), duration = d.Item2 }), interval);
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("window.animator.animateMultible", ElementToAnimate[0], animations.Select(d => new { animation = IFomanticAnimator.ToClass(d.Item1), duration = d.Item2 }));
            }
        }
        /// <inheritdoc/>
        [ComponentAction]
        public Task StopAllAnimation()
        {

            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        [ComponentAction]
        public Task StopCurrentAnimation()
        {
            throw new NotImplementedException();
        }


        /// <inheritdoc/>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
