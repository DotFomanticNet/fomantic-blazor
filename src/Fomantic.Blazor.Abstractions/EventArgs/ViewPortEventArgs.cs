///-------------------------------------------------------------------------------------------------
// file:	EventArgs\ViewPortEventArgs.cs
//
// summary:	Implements the view port event arguments class
///-------------------------------------------------------------------------------------------------

using System;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Delegate of Element Viewport Visibility Change Event. </summary>
    ///
    /// <param name="eventArgs">    . </param>
    ///-------------------------------------------------------------------------------------------------

    public delegate void ViewportVisibilityUpdate(ViewPortEventArgs eventArgs);
    /// <summary>   Element Viewport Visibility Change Event Arguments. </summary>
    public class ViewPortEventArgs : EventArgs
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creating new Element Viewport Visibility Change Event Arguments. </summary>
        ///
        /// <param name="calculation">  The visibility calculations after the change. </param>
        ///-------------------------------------------------------------------------------------------------

        public ViewPortEventArgs(IViewPortCalculation calculation)
        {
            Calculation = calculation;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   The visibility calculations after the change. </summary>
        ///
        /// <value> The calculation. </value>
        ///-------------------------------------------------------------------------------------------------

        public IViewPortCalculation Calculation { get; private set; }
    }

}
