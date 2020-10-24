///-------------------------------------------------------------------------------------------------
// file:	Helpers\ISegmantGroupHelpers.cs
//
// summary:	Declares the ISegmantGroupHelpers interface
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Helper Utitities for <see cref="IFomanticGroupComponent{ISegmantGroupChild}" />  as T is
    /// <see cref="ISegmantGroupChild"/>
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public static  class ISegmantGroupHelpers
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Get list of children segments inside a segmant group. </summary>
        ///
        /// <param name="segmantGroup"> Parent segmant group. </param>
        ///
        /// <returns>   list of children segments. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static IEnumerable<Segment> GetChildrenSegments(this IFomanticGroupComponent<ISegmantGroupChild> segmantGroup)
        {
            return segmantGroup.Children.OfType<Segment>();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Get list of children segment groups inside a segmant group. </summary>
        ///
        /// <param name="segmantGroup"> Parent segmant group. </param>
        ///
        /// <returns>   list of children segment groups. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static IEnumerable<SegmentGroup> GetChildrenSegmentGroups(this IFomanticGroupComponent<ISegmantGroupChild> segmantGroup)
        {
            return segmantGroup.Children.OfType<SegmentGroup>().Union(segmantGroup.Children.OfType<Segments>());
        }
    }
}
