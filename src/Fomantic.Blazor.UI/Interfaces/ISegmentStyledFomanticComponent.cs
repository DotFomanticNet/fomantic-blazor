using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    /// <summary>
    /// Base interface for all Fomantic Blazor Segment Components that can be be in different segment style  
    /// </summary>
    public interface ISegmentStyledFomanticComponent : IFomanticComponentWithClass
    {
        /// <summary>
        /// class given to make segment styled raised
        /// </summary>
        const string RaisedClass = "raised";
        /// <summary>
        /// class given to make segment styled stacked
        /// </summary>
        const string StackedClass = "stacked";
        /// <summary>
        /// class given to make segment styled tall stacked
        /// </summary>
        const string TallStackedClass = "tall stacked";
        /// <summary>
        /// class given to make segment styled piled
        /// </summary>
        const string PiledClass = "piled";
        /// <summary>
        /// class given to make segment styled basic
        /// </summary>
        const string BasicClass = "basic";


        /// <summary>
        /// Determine how the segment should be styled
        /// </summary>
        [Parameter]
        public SegmentStyle SegmentStyle { get; set; }

        /// <summary>
        /// Convert <see cref="Fomantic.Blazor.UI.SegmentStyle"/> to given class
        /// </summary>
        /// <param name="style">ContentSpace Value</param>
        /// <returns>Given class from <paramref name="style"/> </returns>
        public static string ToClass(SegmentStyle style)
        {

            return style switch
            {
                SegmentStyle.Normal => string.Empty,
                SegmentStyle.Basic => BasicClass,
                SegmentStyle.Raised => RaisedClass,
                SegmentStyle.Stacked => StackedClass,
                SegmentStyle.TallStacked => TallStackedClass,
                SegmentStyle.Piled => PiledClass,
                _ => string.Empty,
            };
        }
    }
}
