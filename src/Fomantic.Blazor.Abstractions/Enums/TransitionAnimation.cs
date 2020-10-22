namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Type of animation that used to hide show elements/components
    /// </summary>
    public enum TransitionAnimation
    {
        /// <summary>
        /// Animation makes elements/components fade into or out of view descending and ascending
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fade"></see></para>
        /// </remarks>
        Fade = 0,
        /// <summary>
        /// Animation makes elements/components fade into or out of view descending and ascending
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fade"></see></para>
        /// </remarks>
        FadeUp,
        /// <summary>
        /// Animation makes elements/components fade into or out of view descending and ascending
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fade"></see></para>
        /// </remarks>
        FadeDown,
        /// <summary>
        /// Animation makes elements/components fade into or out of view descending and ascending
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fade"></see></para>
        /// </remarks>
        FadeLeft,
        /// <summary>
        /// Animation makes elements/components fade into or out of view descending and ascending
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fade"></see></para>
        /// </remarks>
        FadeRight,
        /// <summary>
        /// Animation makes  elements/components scale into or out of view
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#scale"></see></para>
        /// </remarks>
        Scale,
        /// <summary>
        /// Animation makes elements/components zoom into view from far away
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#zoom"></see></para>
        /// </remarks>
        Zoom,
        /// <summary>
        /// Animation makes elements/components flip into or out of view vertically or horizontally
        /// </summary>    
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#flip"></see></para>
        /// </remarks>
        HorizontalFlip,
        /// <summary>
        /// Animation makes elements/components flip into or out of view vertically or horizontally
        /// </summary>    
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#flip"></see></para>
        /// </remarks>
        VerticalFlip,
        /// <summary>
        /// Animation makes elements/components drop into view from above
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#drop"></see></para>
        /// </remarks>
        Drop,
        /// <summary>
        /// Animation makes elements/components fly in from off canvas
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fly"></see></para>
        /// </remarks>
        FlyUp,
        /// <summary>
        /// Animation makes elements/components fly in from off canvas
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fly"></see></para>
        /// </remarks>
        FlyDown,
        /// <summary>
        /// Animation makes elements/components fly in from off canvas
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fly"></see></para>
        /// </remarks>
        FlyRight,
        /// <summary>
        /// Animation makes elements/components fly in from off canvas
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#fly"></see></para>
        /// </remarks>
        FlyLeft,
        /// <summary>
        /// Animation makes elements/components swing into view
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#swing"></see></para>
        /// </remarks>
        SwingUp,
        /// <summary>
        /// Animation makes elements/components swing into view
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#swing"></see></para>
        /// </remarks>
        SwingDown,
        /// <summary>
        /// Animation makes elements/components swing into view
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#swing"></see></para>
        /// </remarks>
        SwingRight,
        /// <summary>
        /// Animation makes elements/components swing into view
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#swing"></see></para>
        /// </remarks>
        SwingLeft,
        /// <summary>
        /// Animation makes elements/components appear and disappear as part of a series
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#browse"></see></para>
        /// </remarks>
        Browse,
        /// <summary>
        /// Animation makes elements/components appear and disappear as part of a series
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#browse"></see></para>
        /// </remarks>
        BrowseRight,
        /// <summary>
        /// Animation makes elements/components appear to slide in from above or below
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#slide"></see></para>
        /// </remarks>
        SlideUp,
        /// <summary>
        /// Animation makes elements/components appear to slide in from above or below
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#slide"></see></para>
        /// </remarks>
        SlideDown,
        /// <summary>
        /// Animation makes elements/components appear to slide in from above or below
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#slide"></see></para>
        /// </remarks>
        SlideRight,
        /// <summary>
        /// Animation makes elements/components appear to slide in from above or below
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#slide"></see></para>
        /// </remarks>
        SlideLeft
    }
}
