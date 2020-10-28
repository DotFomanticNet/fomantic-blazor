///-------------------------------------------------------------------------------------------------
// file:	Elements\GroupElements\ElementBases\SegmentGroupBase.razor.cs
//
// summary:	Implements the segment group base.razor class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using Fomantic.Blazor.UI;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Fomantic
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// A Container group of segments can be formatted to appear together and could be nested.
    /// </summary>
    ///
    /// <remarks>
    ///  <para>Reference : </para>
    /// <para><see href="https://fomantic-ui.com/elements/segment.html#segments">https://fomantic-ui.com/elements/segment.html#segments</see></para>
    /// </remarks>
    ///-------------------------------------------------------------------------------------------------

    public abstract class SegmentGroupBase : FomanticComponentWithContentBase,
        ISegmentStyledFomanticComponent,
        ISegmantGroupChild,
        IFomanticGroupComponent<ISegmantGroupChild>,
        IFomanticGroupComponentWithAnimatableChildren<ISegmantGroupChild>
    {

        #region Constractors,Dispose and Overrides
        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ParentGroup?.SegmantGroupChildren?.Add(this);

        }
        /// <inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            ChildrenAnimator = new FomanticComponentsAnimator<ISegmantGroupChild>(Children?.ToArray());         
        }

        /// <inheritdoc/>
        protected internal override void ConstractClasses()
        {
           
          
            base.ConstractClasses();
            CssClasses.Insert(1, StackDirection.ToString().ToLower());
            CssClasses.Insert(0, "ui");
            CssClasses.Add("segments");
        }

        #endregion

        #region Parameters
        /// <inheritdoc/>
        [CascadingParameter]
        public SegmentGroup ParentGroup { get; private set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#raised-segments">https://fomantic-ui.com/elements/segment.html#raised-segments"&gt;</see></para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#stacked-segments">https://fomantic-ui.com/elements/segment.html#stacked-segments"&gt;</see></para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#piled-segments">https://fomantic-ui.com/elements/segment.html#piled-segments"&gt;</see></para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#segments">https://fomantic-ui.com/elements/segment.html#segments"&gt;</see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public SegmentStyle SegmentStyle { get; set; } = SegmentStyle.Normal;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine if the segment group should appear horizontally or Verticaly. </summary>
        ///
        /// <remarks>
        /// <para>A horizontal segment group can automatically stack on smaller screens</para>
        /// <para>Reference : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#horizontal-segments"></see></para>
        /// </remarks>
        ///
        /// <value> The stack direction. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public Direction StackDirection { get; set; } = Direction.Vertical;


        #endregion

        #region Props
        /// <inheritdoc/>
        public ReadOnlyCollection<ISegmantGroupChild> Children => new ReadOnlyCollection<ISegmantGroupChild>(SegmantGroupChildren);

        /// <inheritdoc/>
        public IFomanticAnimator ChildrenAnimator { get; set; }
        #endregion

        #region Privates

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the segmant group children. </summary>
        ///
        /// <value> The segmant group children. </value>
        ///-------------------------------------------------------------------------------------------------

        internal List<ISegmantGroupChild> SegmantGroupChildren { get; private set; } = new List<ISegmantGroupChild>();

        #endregion

    }

    //Another name of SegmentGroup

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A segments. </summary>
    ///
    /// ### <inheritdoc/>
    ///-------------------------------------------------------------------------------------------------

    public class Segments : SegmentGroup
    {

    }
}
