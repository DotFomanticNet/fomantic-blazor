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

    public interface IFomanticComponentWithEnterTransition : IVisibleFomanticComponent
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

    }
}
