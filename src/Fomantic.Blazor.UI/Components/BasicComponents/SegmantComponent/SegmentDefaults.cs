///-------------------------------------------------------------------------------------------------
// file:	Elements\BasicElements\Segment.razor.cs
//
// summary:	Implements the segment.razor class
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;

namespace Fomantic
{
    /// <summary>   Contains default values for the segmant creation. </summary>
    public static class SegmentDefaults
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment color assgined when creating any segment. </summary>
        ///
        /// <value> The color default. </value>
        ///-------------------------------------------------------------------------------------------------

        public static Color? ColorDefault { set; get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment content alignment assgined when creating any segment. </summary>
        ///
        /// <value> The content alignment default. </value>
        ///-------------------------------------------------------------------------------------------------

        public static ContentHorizontalAlignment? ContentAlignmentDefault { set; get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment content space assgined when creating any segment. </summary>
        ///
        /// <value> The content space default. </value>
        ///-------------------------------------------------------------------------------------------------

        public static ContentSpace? ContentSpaceDefault { set; get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment enter transition assgined when creating any segment. </summary>
        ///
        /// <value> The enter transition default. </value>
        ///-------------------------------------------------------------------------------------------------

        public static TransitionAnimation? EnterTransitionDefault { set; get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Default segment enter transition duration assgined when creating any segment.
        /// </summary>
        ///
        /// <value> The enter transition duration default. </value>
        ///-------------------------------------------------------------------------------------------------

        public static int EnterTransitionDurationDefault { get; set; } = 800;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment attaching value assgined when creating any segment. </summary>
        ///
        /// <value> The attaching default. </value>
        ///-------------------------------------------------------------------------------------------------

        public static AttachingDirection? AttachingDefault { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment is circular value assgined when creating any segment. </summary>
        ///
        /// <value> True if this  is circular default, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public static bool IsCircularDefault { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment is compact value assgined when creating any segment. </summary>
        ///
        /// <value> True if this  is compact default, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public static bool IsCompactDefault { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment is disabled value assgined when creating any segment. </summary>
        ///
        /// <value> True if this  is disabled default, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public static bool IsDisabledDefault { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment is inverted value assgined when creating any segment. </summary>
        ///
        /// <value> True if this  is inverted default, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public static bool IsInvertedDefault { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment is loading value assgined when creating any segment. </summary>
        ///
        /// <value> True if this  is loading default, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public static bool IsLoadingDefault { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default segment is placeholder value assgined when creating any segment. </summary>
        ///
        /// <value> True if this  is placeholder default, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public static bool IsPlaceholderDefault { get; set; }
    }
}
