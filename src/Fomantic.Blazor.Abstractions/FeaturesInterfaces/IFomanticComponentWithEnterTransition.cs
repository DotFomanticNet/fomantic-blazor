///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithEnterTransition.cs
//
// summary:	Declares the IFomanticComponentWithEnterTransition interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that has enter and exit transition.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticComponentWithEnterTransition : IAnimateableFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Transition used to show the component after the page initilized. </summary>
        ///
        /// <value> The enter transition. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        TransitionAnimation? EnterTransition { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// the Duration of transition used to show the component after the page initilized.
        /// </summary>
        ///
        /// <value> The enter transition duration. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        int EnterTransitionDuration { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether this object entery animation is done.
        /// </summary>
        ///
        /// <value>    True if this object entery animation is done, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        bool IsEnterAnimationDone { get; internal set; }

    }
}
