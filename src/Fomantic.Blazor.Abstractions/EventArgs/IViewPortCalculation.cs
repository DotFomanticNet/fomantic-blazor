///-------------------------------------------------------------------------------------------------
// file:	EventArgs\IViewPortCalculation.cs
//
// summary:	Declares the IViewPortCalculation interface
///-------------------------------------------------------------------------------------------------

namespace Fomantic.Blazor.UI
{
    /// <summary>   Contains all element viewport calculation. </summary>
    public interface IViewPortCalculation
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   css bottom value of the parent element of the component. </summary>
        /// <summary>   Is  parent element of the component bottom not visibile on the viewport. </summary>
        ///
        /// <value> The bottom passed. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? BottomPassed { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is parent element of the component bottom visibile on the viewport. </summary>
        ///
        /// <value> The bottom visible. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? BottomVisible { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the fits. </summary>
        ///
        /// <value> The fits. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? Fits { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Height value of the parent element of the component. </summary>
        ///
        /// <value> The height. </value>
        ///-------------------------------------------------------------------------------------------------

        long? Height { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is the parent element of the component not visibile on the viewport. </summary>
        ///
        /// <value> The off screen. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? OffScreen { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is the parent element of the component visibile on the viewport. </summary>
        ///
        /// <value> The on screen. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? OnScreen { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is the parent element of the component passing on the viewport. </summary>
        ///
        /// <value> The passing. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? Passing { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// A distance from the top of parent element of the component content has been passed as
        /// percentage.
        /// </summary>
        ///
        /// <value> The percentage passed. </value>
        ///-------------------------------------------------------------------------------------------------

        double? PercentagePassed { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// A distance from the top of parent element of the component content has been passed as pixels.
        /// </summary>
        ///
        /// <value> The pixels passed. </value>
        ///-------------------------------------------------------------------------------------------------

        long? PixelsPassed { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is parent element of the component top visibile on the viewport. </summary>
        ///
        /// <value> The top visible. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? TopVisible { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is parent element of the component top passed on the viewport. </summary>
        ///
        /// <value> The top passed. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? TopPassed { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   css top value of the parent element of the component. </summary>
        /// <summary>   Width value of the parent element of the component. </summary>
        ///
        /// <value> The width. </value>
        ///-------------------------------------------------------------------------------------------------

        long? Width { get; }
    }
}