///-------------------------------------------------------------------------------------------------
// file:	FomanticBase\ViewportVisibility\ViewPortCalculation.cs
//
// summary:	Implements the view port calculation class
///-------------------------------------------------------------------------------------------------

namespace Fomantic.Blazor.UI
{
    /// <summary>   Contains all element viewport calculation. </summary>
    public class ViewPortCalculation : IViewPortCalculation
    {
     
       // public long? Bottom { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is  parent element of the component bottom not visibile on the viewport. </summary>
        ///
        /// <value> The bottom passed. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool? BottomPassed { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is parent element of the component bottom visibile on the viewport. </summary>
        ///
        /// <value> The bottom visible. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool? BottomVisible { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the fits. </summary>
        ///
        /// <value> The fits. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool? Fits { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Height value of the parent element of the component. </summary>
        ///
        /// <value> The height. </value>
        ///-------------------------------------------------------------------------------------------------

        public long? Height { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is the parent element of the component not visibile on the viewport. </summary>
        ///
        /// <value> The off screen. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool? OffScreen { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is the parent element of the component visibile on the viewport. </summary>
        ///
        /// <value> The on screen. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool? OnScreen { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is the parent element of the component passing on the viewport. </summary>
        ///
        /// <value> The passing. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool? Passing { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// A distance from the top of parent element of the component content has been passed as
        /// percentage.
        /// </summary>
        ///
        /// <value> The percentage passed. </value>
        ///-------------------------------------------------------------------------------------------------

        public double? PercentagePassed { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// A distance from the top of parent element of the component content has been passed as pixels.
        /// </summary>
        ///
        /// <value> The pixels passed. </value>
        ///-------------------------------------------------------------------------------------------------

        public long? PixelsPassed { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is parent element of the component top visibile on the viewport. </summary>
        ///
        /// <value> The top visible. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool? TopVisible { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Is parent element of the component top passed on the viewport. </summary>
        ///
        /// <value> The top passed. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool? TopPassed { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   css top value of the parent element of the component. </summary>
        /// <summary>   Width value of the parent element of the component. </summary>
        ///
        /// <value> The width. </value>
        ///-------------------------------------------------------------------------------------------------

        public long? Width { get; set; }
        //offset: {top: 104, left: 535.109375}
    }
}
