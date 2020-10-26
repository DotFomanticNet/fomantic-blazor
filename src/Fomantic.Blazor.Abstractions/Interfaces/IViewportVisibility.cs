namespace Fomantic.Blazor.UI
{
    /// <summary>   Extention Responsible for Viewport Visibility tracking. </summary>
    public interface IViewportVisibility : IFomanticExtension
    {

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Current View Port Calculations. </summary>
        ///
        /// <value> The calculation. </value>
        ///-------------------------------------------------------------------------------------------------
        ViewPortCalculation Calculation { get; }





        /// <summary>   Event queue for all listeners interested in OnTopVisibleUpdated events. </summary>
        internal event ViewportVisibilityUpdate OnTopVisibleUpdated;
        /// <summary>   Event queue for all listeners interested in OnTopPassedUpdated events. </summary>
        internal event ViewportVisibilityUpdate OnTopPassedUpdated;
        /// <summary>   Event queue for all listeners interested in OnBottomVisibleUpdated events. </summary>
        internal event ViewportVisibilityUpdate OnBottomVisibleUpdated;
        /// <summary>   Event queue for all listeners interested in OnPassingUpdated events. </summary>
        internal event ViewportVisibilityUpdate OnPassingUpdated;
        /// <summary>   Event queue for all listeners interested in OnBottomPassedUpdated events. </summary>
        internal event ViewportVisibilityUpdate OnBottomPassedUpdated;
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnTopVisibleReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------
        internal event ViewportVisibilityUpdate OnTopVisibleReverseUpdated;
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnTopPassedReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------
        internal event ViewportVisibilityUpdate OnTopPassedReverseUpdated;
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnBottomVisibleReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------
        internal event ViewportVisibilityUpdate OnBottomVisibleReverseUpdated;
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnPassingReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------
        internal event ViewportVisibilityUpdate OnPassingReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnBottomPassedReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------
        internal event ViewportVisibilityUpdate OnBottomPassedReverseUpdated;
    }
}