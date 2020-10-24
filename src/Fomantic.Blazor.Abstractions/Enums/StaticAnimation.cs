///-------------------------------------------------------------------------------------------------
// file:	Enums\StaticAnimation.cs
//
// summary:	Implements the static animation class
///-------------------------------------------------------------------------------------------------

namespace Fomantic.Blazor.UI
{
    /// <summary>   Type of animation that used to draw attention to elements/components. </summary>
    public enum StaticAnimation
    {
        /// <summary>
        /// Animation makes elements/components jiggle to draw attention to its shape
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#jiggle"></see></para>
        /// </remarks>
        Jiggle =0,
        /// <summary>
        /// Animation makes elements/components flash to draw attention to itself
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#flash"></see></para>
        /// </remarks>
        Flash,
        /// <summary>
        /// Animation makes elements/components shake to draw attention to its position
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#shake"></see></para>
        /// </remarks>
        Shake,
        /// <summary>
        /// Animation makes elements/components pulse to draw attention to its visibility
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#pulse"></see></para>
        /// </remarks>
        Pulse,
        /// <summary>
        /// Animation makes elements/components give user positive feedback for an action
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#tada"></see></para>
        /// </remarks>
        Tada,
        /// <summary>
        /// Animation makes elements/components bounce to politely remind you of itself
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#bounce"></see></para>
        /// </remarks>
        Bounce,
        /// <summary>
        /// Animation makes elements/components glow to show its position in a page.
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/modules/transition.html#glow"></see></para>
        /// </remarks>
        Glow
    }
}
