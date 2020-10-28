///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IVisibleBlazorComponent.cs
//
// summary:	Declares the IVisibleBlazorComponent interface
///-------------------------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that Visible within view port.
    /// </summary>
    ///
    ///-------------------------------------------------------------------------------------------------
    public interface IVisibleFomanticComponent : IFomanticComponentWithClass, IFomanticComponentWithExtensions
    {

        /// <summary>   Show the entire component if hidden. </summary>

        [ComponentAction]
        void Show();

        /// <summary>   Hide the entire component if showen. </summary>

        [ComponentAction]
        void Hide();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determinate if the component hidden or not. </summary>
        ///
        /// <value> True if this  is hidden, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool IsHidden { get; set; }

        /// <summary>   Toggle the entire component between shown or hiddin. </summary>

        [ComponentAction]
        void ToggleVisibility();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time component patent element Viewport Visibility calculations are.
        /// </summary>
        ///
        /// <value> The on viewport visibility change. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnViewportVisibilityChange { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's top edge has passed bottom of screen.
        /// </summary>
        ///
        /// <value> The on top visible. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisible { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's top edge has passed top of the screen.
        /// </summary>
        ///
        /// <value> The on top passed. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassed { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's bottom edge has passed bottom of screen.
        /// </summary>
        ///
        /// <value> The on bottom visible. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisible { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Occurs when Any part of an component patent element is visible on screen. </summary>
        ///
        /// <value> The on passing. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassing { get; set; }


        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's bottom edge has passed top of screen.
        /// </summary>
        ///
        /// <value> The on bottom passed. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassed { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's top edge has not passed bottom of screen.
        /// </summary>
        ///
        /// <value> The on top visible reverse. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisibleReverse { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's top edge has not passed top of the screen.
        /// </summary>
        ///
        /// <value> The on top passed reverse. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassedReverse { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's bottom edge has not passed bottom of screen.
        /// </summary>
        ///
        /// <value> The on bottom visible reverse. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisibleReverse { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's top has not passed top of screen but bottom
        /// has.
        /// </summary>
        ///
        /// <value> The on passing reverse. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassingReverse { get; set; }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Occurs each time when component patent element's bottom edge has not passed top of screen.
        /// </summary>
        ///
        /// <value> The on bottom passed reverse. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassedReverse { get; set; }





        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Object responsible for Viewport Visibility tracking. </summary>
        ///
        /// <value> The viewport visibility. </value>
        ///-------------------------------------------------------------------------------------------------
        IViewportVisibility GetViewportVisibility() { return (IViewportVisibility)Extensions.FirstOrDefault(d => d is IViewportVisibility); }
    }
}
