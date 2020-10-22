using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{

    /// <summary>
    /// Base interface for all Fomantic Blazor Components that Visible within view port
    /// </summary>
    public interface IVisibleFomanticComponent : IFomanticComponentWithClass
    {
        /// <summary>
        /// class given to the component to invert its color
        /// </summary>
        const string HiddenClass = "transition hidden";
        /// <summary>
        /// Animator responsible for animating the component
        /// </summary>
        [NestedParamter]
        public IFomanticAnimator Animator { get; }

        /// <summary>
        /// Show the entire component if hidden
        /// </summary>
        /// <returns></returns>
        [ComponentAction]
        void Show();

        /// <summary>
        /// Hide the entire component if showen
        /// </summary>
        /// <returns></returns>
        [ComponentAction]
        void Hide();

        /// <summary>
        /// Determinate if the component hidden or not
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Toggle the entire component between shown or hiddin
        /// </summary>
        /// <returns></returns>
        [ComponentAction]
        void ToggleVisibility();

        /// <summary>
        /// Occurs each time component patent element Viewport Visibility calculations are updated
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnViewportVisibilityUpdated { get; set; }
        /// <summary>
        /// Occurs each time component patent element Viewport Visibility calculations are updated
        /// </summary>
        public event ViewportVisibilityUpdate OnViewportVisibilityUpdatedEvent;


        /// <summary>
        /// Occurs each time when component patent element's top edge has passed bottom of screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisibilityUpdated { get; set; }
        /// <summary>
        /// Occurs each time when component patent element's top edge has passed bottom of screen
        /// </summary>
        public event ViewportVisibilityUpdate OnTopVisibilityUpdatedEvent;


        /// <summary>
        ///  Occurs each time when component patent element's top edge has passed top of the screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassedUpdated { get; set; }
        /// <summary>
        ///  Occurs each time when component patent element's top edge has passed top of the screen
        /// </summary>
        public event ViewportVisibilityUpdate OnTopPassedUpdatedEvent;

        /// <summary>
        ///  Occurs each time when component patent element's bottom edge has passed bottom of screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisibleUpdated { get; set; }
        /// <summary>
        ///  Occurs each time when component patent element's bottom edge has passed bottom of screen
        /// </summary>
        public event ViewportVisibilityUpdate OnBottomVisibleUpdatedEvent;


        /// <summary>
        ///  Occurs when Any part of an component patent element is visible on screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassingUpdated { get; set; }
        /// <summary>
        ///  Occurs when Any part of an component patent element is visible on screen
        /// </summary>
        public event ViewportVisibilityUpdate OnPassingUpdatedEvent;

        /// <summary>
        ///  Occurs each time when component patent element's bottom edge has passed top of screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassedUpdated { get; set; }
        /// <summary>
        ///  Occurs each time when component patent element's bottom edge has passed top of screen
        /// </summary>
        public event ViewportVisibilityUpdate OnBottomPassedUpdatedEvent;

        /// <summary>
        ///  Occurs each time when component patent element's top edge has not passed bottom of screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisibleReverseUpdated { get; set; }
        /// <summary>
        ///  Occurs each time when component patent element's top edge has not passed bottom of screen
        /// </summary>
        public event ViewportVisibilityUpdate OnTopVisibleReverseUpdatedEvent;

        /// <summary>
        ///  Occurs each time when component patent element's top edge has not passed top of the screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassedReverseUpdated { get; set; }
        /// <summary>
        ///  Occurs each time when component patent element's top edge has not passed top of the screen
        /// </summary>
        public event ViewportVisibilityUpdate OnTopPassedReverseUpdatedEvent;

        /// <summary>
        ///  Occurs each time when component patent element's bottom edge has not passed bottom of screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisibleReverseUpdated { get; set; }
        /// <summary>
        ///  Occurs each time when component patent element's bottom edge has not passed bottom of screen
        /// </summary>
        public event ViewportVisibilityUpdate OnBottomVisibleReverseUpdatedEvent;

        /// <summary>
        ///  Occurs each time when component patent element's top has not passed top of screen but bottom has
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassingReverseUpdated { get; set; }
        /// <summary>
        ///  Occurs each time when component patent element's top has not passed top of screen but bottom has
        /// </summary>
        public event ViewportVisibilityUpdate OnPassingReverseUpdatedEvent;

        /// <summary>
        ///  Occurs each time when component patent element's bottom edge has not passed top of screen
        /// </summary>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassedReverseUpdated { get; set; }
        /// <summary>
        ///  Occurs each time when component patent element's bottom edge has not passed top of screen
        /// </summary>
        public event ViewportVisibilityUpdate OnBottomPassedReverseUpdatedEvent;
    }
}
