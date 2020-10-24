namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Contains all element viewport calculation
    /// </summary>
    public interface IViewPortCalculation
    {
        /// <summary>
        /// css bottom value of the parent element of the component 
        /// </summary>
      //  long? Bottom { get; }
        /// <summary>
        /// Is  parent element of the component bottom not visibile on the viewport
        /// </summary>
        bool? BottomPassed { get; }
        /// <summary>
        /// Is parent element of the component bottom visibile on the viewport
        /// </summary>
        bool? BottomVisible { get; }
        /// <summary>
        /// 
        /// </summary>
        bool? Fits { get; }
        /// <summary>
        /// Height value of the parent element of the component 
        /// </summary>
        long? Height { get; }
        /// <summary>
        /// Is the parent element of the component not visibile on the viewport
        /// </summary>
        bool? OffScreen { get; }
        /// <summary>
        /// Is the parent element of the component visibile on the viewport
        /// </summary>
        bool? OnScreen { get; }
        /// <summary>
        /// Is the parent element of the component passing on the viewport
        /// </summary>
        bool? Passing { get; }
        /// <summary>
        /// A distance from the top of parent element of the component content has been passed as percentage
        /// </summary>
        double? PercentagePassed { get; }
        /// <summary>
        /// A distance from the top of parent element of the component content has been passed as pixels
        /// </summary>
        long? PixelsPassed { get; }
        /// <summary>
        /// Is parent element of the component top visibile on the viewport
        /// </summary>
        bool? TopVisible { get; }
        /// <summary>
        ///  Is parent element of the component top passed on the viewport
        /// </summary>
        bool? TopPassed { get; }
        /// <summary>
        ///  css top value of the parent element of the component 
        /// </summary>
       // long? Top { get; }
        /// <summary>
        ///  Width value of the parent element of the component 
        /// </summary>
        long? Width { get; }
    }
}