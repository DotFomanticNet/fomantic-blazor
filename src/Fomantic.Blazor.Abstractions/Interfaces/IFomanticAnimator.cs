///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticAnimator.cs
//
// summary:	Declares the IFomanticAnimator interface
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomantic.Blazor.UI;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base Interface for a Fomantic Animators. </summary>
    public interface IFomanticAnimator : IDisposable
    {
        #region Transition Animation Names
        /// <summary>   Given animation name to scale. </summary>
        const string ScaleAnimationName = "scale";
        /// <summary>   Given animation name to zoom. </summary>
        const string ZoomAnimationName = "zoom";
        /// <summary>   Given animation name to fade. </summary>
        const string FadeAnimationName = "fade";
        /// <summary>   Given animation name to fade up. </summary>
        const string FadeUpAnimationName = "fade up";
        /// <summary>   Given animation name to fade down. </summary>
        const string FadeDownAnimationName = "fade down";
        /// <summary>   Given animation name to fade left. </summary>
        const string FadeLeftAnimationName = "fade left";
        /// <summary>   Given animation name to fade right. </summary>
        const string FadeRightAnimationName = "fade right";
        /// <summary>   Given animation name to horizontal flip. </summary>
        const string HorizontalFlipAnimationName = "horizontal flip";
        /// <summary>   Given animation name to vertical flip. </summary>
        const string VerticalFlipAnimationName = "vertical flip";
        /// <summary>   Given animation name to drop. </summary>
        const string DropAnimationName = "drop";
        /// <summary>   Given animation name to fly up. </summary>
        const string FlyUpAnimationName = "fly up";
        /// <summary>   Given animation name to fly down. </summary>
        const string FlyDownAnimationName = "fly down";
        /// <summary>   Given animation name to fly right. </summary>
        const string FlyRightAnimationName = "fly right";
        /// <summary>   Given animation name to swing left. </summary>
        const string FlyLeftAnimationName = "fly left";
        /// <summary>   Given animation name to swing up. </summary>
        const string SwingUpAnimationName = "swing up";
        /// <summary>   Given animation name to swing down. </summary>
        const string SwingDownAnimationName = "swing down";
        /// <summary>   Given animation name to swing right. </summary>
        const string SwingRightAnimationName = "swing right";
        /// <summary>   Given animation name to swing left. </summary>
        const string SwingLeftAnimationName = "swing left";
        /// <summary>   Given animation name to browse. </summary>
        const string BrowseAnimationName = "browse";
        /// <summary>   Given animation name to browse right. </summary>
        const string BrowseRightAnimationName = "browse right";
        /// <summary>   Given animation name to slide up. </summary>
        const string SlideUpAnimationName = "slide up";
        /// <summary>   Given animation name to slide down. </summary>
        const string SlideDownAnimationName = "slide down";
        /// <summary>   Given animation name to slide right. </summary>
        const string SlideRightAnimationName = "slide right";
        /// <summary>   Given animation name to slide left. </summary>
        const string SlideLeftAnimationName = "slide left";

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="TransitionAnimation"/> to given animation name. </summary>
        ///
        /// <param name="animation">    Animation value. </param>
        ///
        /// <returns>   given class from <paramref name="animation"/> </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToClass(TransitionAnimation animation) => animation switch
        {
            TransitionAnimation.Scale => ScaleAnimationName,
            TransitionAnimation.Zoom => ZoomAnimationName,
            TransitionAnimation.Fade => FadeAnimationName,
            TransitionAnimation.FadeUp => FadeUpAnimationName,
            TransitionAnimation.FadeDown => FadeDownAnimationName,
            TransitionAnimation.FadeLeft => FadeLeftAnimationName,
            TransitionAnimation.FadeRight => FadeRightAnimationName,
            TransitionAnimation.HorizontalFlip => HorizontalFlipAnimationName,
            TransitionAnimation.VerticalFlip => VerticalFlipAnimationName,
            TransitionAnimation.Drop => DropAnimationName,
            TransitionAnimation.FlyUp => FlyUpAnimationName,
            TransitionAnimation.FlyDown => FlyDownAnimationName,
            TransitionAnimation.FlyRight => FlyRightAnimationName,
            TransitionAnimation.FlyLeft => FlyLeftAnimationName,
            TransitionAnimation.SwingUp => SwingUpAnimationName,
            TransitionAnimation.SwingDown => SwingDownAnimationName,
            TransitionAnimation.SwingRight => SwingRightAnimationName,
            TransitionAnimation.SwingLeft => SwingLeftAnimationName,
            TransitionAnimation.Browse => BrowseAnimationName,
            TransitionAnimation.BrowseRight => BrowseRightAnimationName,
            TransitionAnimation.SlideUp => SlideUpAnimationName,
            TransitionAnimation.SlideDown => SlideDownAnimationName,
            TransitionAnimation.SlideRight => SlideRightAnimationName,
            TransitionAnimation.SlideLeft => SlideLeftAnimationName,
            _ => string.Empty,
        };
        #endregion

        #region Static Animation Names
        /// <summary>   Given animation name to jiggle. </summary>
        const string JiggleAnimationName = "jiggle";
        /// <summary>   Given animation name to flash. </summary>
        const string FlashAnimationName = "flash";
        /// <summary>   Given animation name to shake. </summary>
        const string ShakeAnimationName = "shake";
        /// <summary>   Given animation name to pulse. </summary>
        const string PulseAnimationName = "pulse";
        /// <summary>   Given animation name to bounce. </summary>
        const string BounceAnimationName = "bounce";
        /// <summary>   Given animation name to tada. </summary>
        const string TadaAnimationName = "tada";
        /// <summary>   Given animation name to glow. </summary>
        const string GlowAnimationName = "glow";

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="StaticAnimation"/> to given animation name. </summary>
        ///
        /// <param name="animation">    animation value. </param>
        ///
        /// <returns>   given class from <paramref name="animation"/> </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToClass(StaticAnimation animation) => animation switch
        {
            StaticAnimation.Jiggle => JiggleAnimationName,
            StaticAnimation.Flash => FlashAnimationName,
            StaticAnimation.Shake => ShakeAnimationName,
            StaticAnimation.Pulse => PulseAnimationName,
            StaticAnimation.Tada => TadaAnimationName,
            StaticAnimation.Bounce => BounceAnimationName,
            StaticAnimation.Glow => GlowAnimationName,
            _ => string.Empty,
        };

        #endregion

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target once with a static animation into a task and it will be done once
        /// animation done.
        /// </summary>
        ///
        /// <param name="animation">    A static animation to apply in the target. </param>
        /// <param name="duration">     (Optional) The duration in MS of the animation. </param>
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        Task Animate(StaticAnimation animation, int duration = 800, int interval = 200);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target with a sequence of static animations into a task and it will be done all
        /// animation done.
        /// </summary>
        ///
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        /// <param name="animations">   Tuples contain each static animation  to apply in the target and
        ///                             its duration. </param>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------
       
        Task Animate(int interval = 200, params Tuple<StaticAnimation, int>[] animations);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target once with a static animation into a task and it will be done once
        /// animation done , Once animation done element will be transit into show or hiddin.  
        /// </summary>
        ///
        /// <param name="animation">    A transition animation to apply on the target. </param>
        /// <param name="duration">     (Optional) The duration in MS of the animation. </param>
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        Task Animate(TransitionAnimation animation, int duration = 800, int interval = 200);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target with a sequence of transition animations into a task and it will be done
        /// all animation done , Once animation done element will be transit into show or hiddin.  
        /// </summary>
        ///
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        /// <param name="animations">   Tuples contain each transition animation to apply on the target
        ///                             and its duration. </param>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------
      
        Task Animate(int interval = 200,params Tuple<TransitionAnimation, int>[] animations);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target once with a static animation without waiting to be ended.
        /// </summary>
        ///
        /// <param name="animation">    A transition animation to apply on the target. </param>
        /// <param name="duration">     (Optional) The duration in MS of the animation. </param>
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        ///
        /// ### <returns>   . </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        void QueueAnimation(StaticAnimation animation, int duration = 800, int interval = 200);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target with a sequence of static animations without waiting to be ended.
        /// </summary>
        ///
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        /// <param name="animations">   Tuples contain each static animation  on apply in the target and
        ///                             its duration. </param>
        ///
        /// ### <returns>   . </returns>
        ///-------------------------------------------------------------------------------------------------
      
        void QueueAnimation(int interval = 200, params Tuple<StaticAnimation, int>[] animations);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target once with a static animation  without waiting to be ended.
        /// </summary>
        ///
        /// <param name="animation">    A transition animation to apply on the target. </param>
        /// <param name="duration">     (Optional) The duration in MS of the animation. </param>
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        ///
        /// ### <returns>   . </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        void QueueAnimation(TransitionAnimation animation, int duration = 800, int interval = 200);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target with a sequence of transition animations without waiting to be ended.
        /// </summary>
        ///
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        /// <param name="animations">   Tuples contain each transition animation to apply on the target
        ///                             and its duration. </param>
        ///
        /// ### <returns>   . </returns>
        ///-------------------------------------------------------------------------------------------------
     
        void QueueAnimation(int interval = 200, params Tuple<TransitionAnimation, int>[] animations);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target once with a static animation into a task and it will be done once
        /// animation done , Once animation done element will be showen.
        /// </summary>
        ///
        /// <param name="animation">    A transition animation to apply on the target. </param>
        /// <param name="duration">     (Optional) The duration in MS of the animation. </param>
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        Task AnimatedShow(TransitionAnimation animation, int duration = 800, int interval = 200);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target once with a static animation without waiting to be ended, Once animation
        /// done element will be showen.
        /// </summary>
        ///
        /// <param name="animation">    A transition animation to apply on the target. </param>
        /// <param name="duration">     (Optional) The duration in MS of the animation. </param>
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        ///
        /// ### <returns>   . </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        void QueueAnimatedShow(TransitionAnimation animation, int duration = 800, int interval = 200);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target once with a static animation into a task and it will be done once
        /// animation done , Once animation done element will be hiddin.
        /// </summary>
        ///
        /// <param name="animation">    A transition animation to apply on the target. </param>
        /// <param name="duration">     (Optional) The duration in MS of the animation. </param>
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        Task AnimatedHide(TransitionAnimation animation, int duration = 800, int interval = 200);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Animate the target once with a static animation into a task and it will be done once
        /// animation done , Once animation done element will be hiddin.
        /// </summary>
        ///
        /// <param name="animation">    A transition animation to apply on the target. </param>
        /// <param name="duration">     (Optional) The duration in MS of the animation. </param>
        /// <param name="interval">     (Optional) Interval in MS between each elements transition. </param>
        ///
        /// ### <returns>   . </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        void QueueAnimatedHide(TransitionAnimation animation, int duration = 800, int interval = 200);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Stop current animation and preserve queue. </summary>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        Task StopCurrentAnimation();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Stop current animation and queued animations. </summary>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------

        [ComponentAction]
        Task StopAllAnimation();
    }
}
