///-------------------------------------------------------------------------------------------------
// file:	Elements\BasicElements\ElementBases\IconBase.razor.cs
//
// summary:	Implements the icon base.razor class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Fomantic
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An icon is a glyph used to represent something else. </summary>
    ///
    /// <remarks>
    ///  <para>Reference : </para>
    /// <para><see href="https://fomantic-ui.com/elements/icon.html">https://fomantic-ui.com/elements/icon.html</see></para>
    /// </remarks>
    ///-------------------------------------------------------------------------------------------------

    public abstract class IconBase : FomanticComponentBase,
        IFomanticComponentWithColor,
        IFomanticComponentWithSize,
        IFomanticComponentCanBeDisabled,
        IFomanticComponentWithInvertedStyle,
        IFomanticComponentWithFittedStyle,
        IFomanticComponentWithCircularStyle


    {
        /// <inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

        }

        /// <inheritdoc/>
        protected internal override void ConstractClasses()
        {

            base.ConstractClasses();
            CssClasses.Add(Icon.ToCssClass());
            CssClasses.Add("icon");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// A circular segment will most likely have to have its content manually sized to be equal width
        /// and height, otherwise it will flow to the size of your content.
        /// <para>Reference : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#circular">https://fomantic-ui.com/elements/icon.html#circular</see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsCircular { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#size"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public Size Size { get; set; } = Size.Medium;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#colored"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public Color? Color { get; set; } = null;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#/icon"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public IconList Icon { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#inverted"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsInverted { get; set; } = false;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#disabled"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsDisabled { get; set; } = false;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#fitted"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsFitted { get; set; }



    }
}
