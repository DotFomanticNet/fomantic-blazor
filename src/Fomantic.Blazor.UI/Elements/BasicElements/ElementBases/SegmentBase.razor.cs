///-------------------------------------------------------------------------------------------------
// file:	Elements\BasicElements\ElementBases\SegmentBase.razor.cs
//
// summary:	Implements the segment base.razor class
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// A segment is used to create a grouping of related content
    /// <para><see href="https://fomantic-ui.com/elements/segment.html">https://fomantic-ui.com/elements/segment.html</see></para>
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public abstract class SegmentBase : FomanticComponentWithContentBase,
        IFomanticGroupComponentChild<SegmentGroup>,
        ISegmantGroupChild,
        IFomanticComponentWithColor,
        IFomanticComponentCanBeDisabled,
        IFomanticComponentWithInvertedStyle,
        IFomanticComponentWithCompactStyle,
        IFomanticComponentWithLoadingIndicator,
        IFomanticComponentWithContentAlignment,
        IFomanticComponentWithContentSpacing,
        IFomanticComponentWithCircularStyle,
        IAttachableFomanticComponent,
        ISegmentStyledFomanticComponent

    {
        /// <summary>   The placeholder class. </summary>
        const string PlaceholderClass = "placeholder";
      

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ParentGroup?.SegmantGroupChildren.Add(this);

        }
        /// <inheritdoc/>
        protected internal override void ConstractClasses()
        {
           
          
            base.ConstractClasses();
            if (IsPlaceholder)
            {
                CssClasses.Insert(1, PlaceholderClass);
            }
            CssClasses.Insert(0, "ui");
            CssClasses.Add("segment");
        }
        /// <inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            
            base.OnAfterRender(firstRender);


        }

        /// <inheritdoc/>
        [CascadingParameter]
        public SegmentGroup ParentGroup { get; private set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Determine if the component should be used to reserve space for conditionally displayed
        /// content.
        /// </summary>
        ///
        /// <remarks>
        ///  <para>Reference : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#placeholder-segment">https://fomantic-ui.com/elements/segment.html#placeholder-segment</see></para>
        /// </remarks>
        ///
        /// <value> True if this  is placeholder, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsPlaceholder { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// A circular segment will most likely have to have its content manually sized to be equal width
        /// and height, otherwise it will flow to the size of your content.
        /// <para>Reference : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#circular">https://fomantic-ui.com/elements/segment.html#circular</see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsCircular { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>Reference : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#colored">https://fomantic-ui.com/elements/segment.html#colored</see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public Color? Color { get; set; } = null;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#raised">https://fomantic-ui.com/elements/segment.html#raised</see></para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#stacked">https://fomantic-ui.com/elements/segment.html#stacked</see></para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#piled">https://fomantic-ui.com/elements/segment.html#piled</see></para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#basic">https://fomantic-ui.com/elements/segment.html#basic</see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public SegmentStyle SegmentStyle { get; set; } = SegmentStyle.Normal;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#inverted"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsInverted { get; set; } = false;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#disabled"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsDisabled { get; set; } = false;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#loading"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsLoading { get; set; } = false;

        /// <inheritdoc/>
        [Parameter]
        public ContentAlignment? ContentAlignment { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public ContentSpace? ContentSpace { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#compact"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsCompact { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/segment.html#attached"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public AttachingDirection? Attaching { get; set; }
    }
}
