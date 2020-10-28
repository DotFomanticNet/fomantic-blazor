///-------------------------------------------------------------------------------------------------
// file:	Elements\BasicElements\Segment.razor.cs
//
// summary:	Implements the segment.razor class
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic
{

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A segment. </summary>
    ///
    /// ### <inheritdoc/>
    ///-------------------------------------------------------------------------------------------------

    public partial class Segment
    {

        /// <summary>   Create new Segment. </summary>
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
