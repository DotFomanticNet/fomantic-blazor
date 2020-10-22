namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Contains all element viewport calculation
    /// </summary>
    internal class ViewPortCalculation : IViewPortCalculation
    {
     
        public int Bottom { get; set; }
        /// <summary>
        /// Is  parent element of the component bottom not visibile on the viewport
        /// </summary>
        public bool BottomPassed { get; set; }
        /// <summary>
        /// Is parent element of the component bottom visibile on the viewport
        /// </summary>
        public bool BottomVisible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Fits { get; set; }
        /// <summary>
        /// Height value of the parent element of the component 
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Is the parent element of the component not visibile on the viewport
        /// </summary>
        public bool OffScreen { get; set; }
        /// <summary>
        /// Is the parent element of the component visibile on the viewport
        /// </summary>
        public bool OnScreen { get; set; }
        /// <summary>
        /// Is the parent element of the component passing on the viewport
        /// </summary>
        public bool Passing { get; set; }
        /// <summary>
        /// A distance from the top of parent element of the component content has been passed as percentage
        /// </summary>
        public double PercentagePassed { get; set; }
        /// <summary>
        /// A distance from the top of parent element of the component content has been passed as pixels
        /// </summary>
        public int PixelsPassed { get; set; }
        /// <summary>
        /// Is parent element of the component top visibile on the viewport
        /// </summary>
        public bool TopVisible { get; set; }
        /// <summary>
        ///  Is parent element of the component top passed on the viewport
        /// </summary>
        public bool TopPassed { get; set; }
        /// <summary>
        ///  css top value of the parent element of the component 
        /// </summary>
        public int Top { get; set; }
        /// <summary>
        ///  Width value of the parent element of the component 
        /// </summary>
        public int Width { get; set; }
        //offset: {top: 104, left: 535.109375}
    }
}
