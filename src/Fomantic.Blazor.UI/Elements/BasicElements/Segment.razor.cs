using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic
{
    /// <summary>
    /// Contains default values for the segmant creation
    /// </summary>
    public static class SegmentDefaults
    {
        /// <summary>
        /// Default segment color assgined when creating any segment
        /// </summary>
        public static Color? ColorDefault { set; get; } = null;

        /// <summary>
        /// Default segment content alignment assgined when creating any segment
        /// </summary>
        public static ContentAlignment? ContentAlignmentDefault { set; get; } = null;

        /// <summary>
        /// Default segment content space assgined when creating any segment
        /// </summary>
        public static ContentSpace? ContentSpaceDefault { set; get; } = null;

        /// <summary>
        /// Default segment enter transition assgined when creating any segment
        /// </summary>
        public static TransitionAnimation? EnterTransitionDefault { set; get; } = null;

        /// <summary>
        /// Default segment enter transition duration assgined when creating any segment
        /// </summary>
        public static int EnterTransitionDurationDefault { get; set; } = 800;
        /// <summary>
        /// Default segment attaching value assgined when creating any segment
        /// </summary>
        public static AttachingDirection? AttachingDefault { get; set; } = null;
        /// <summary>
        /// Default segment is circular value assgined when creating any segment
        /// </summary>
        public static bool IsCircularDefault { get; set; } = false;
        /// <summary>
        /// Default segment is compact value assgined when creating any segment
        /// </summary>
        public static bool IsCompactDefault { get; set; } = false;
        /// <summary>
        /// Default segment is disabled value assgined when creating any segment
        /// </summary>
        public static bool IsDisabledDefault { get; set; } = false;
        /// <summary>
        /// Default segment is inverted value assgined when creating any segment
        /// </summary>
        public static bool IsInvertedDefault { get; set; } = false;
        /// <summary>
        /// Default segment is loading value assgined when creating any segment
        /// </summary>
        public static bool IsLoadingDefault { get; set; } = false;
        /// <summary>
        /// Default segment is placeholder value assgined when creating any segment
        /// </summary>
        public static bool IsPlaceholderDefault { get; set; } = false;
    }
    ///<inheritdoc/>
    public partial class Segment
    {

        /// <summary>
        /// Create new Segment
        /// </summary>
        public Segment()
        {
            Color = SegmentDefaults.ColorDefault;
            ContentAlignment = SegmentDefaults.ContentAlignmentDefault;
            ContentSpace = SegmentDefaults.ContentSpaceDefault;
            EnterTransition = SegmentDefaults.EnterTransitionDefault;
            EnterTransitionDuration = SegmentDefaults.EnterTransitionDurationDefault;
            Attaching = SegmentDefaults.AttachingDefault;
            IsCircular = SegmentDefaults.IsCircularDefault;
            IsCompact = SegmentDefaults.IsCompactDefault;
            IsDisabled = SegmentDefaults.IsDisabledDefault;
            IsInverted = SegmentDefaults.IsInvertedDefault;
            IsLoading = SegmentDefaults.IsLoadingDefault;
            IsPlaceholder = SegmentDefaults.IsPlaceholderDefault;

        }
    }
}
