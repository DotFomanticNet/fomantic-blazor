///-------------------------------------------------------------------------------------------------
// file:	Elements\BasicElements\ElementBases\HeaderBase.razor.cs
//
// summary:	Implements the header base.razor class
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
    /// <summary>   A text is used to style some inline text with a simple color. </summary>
    ///
    /// <remarks>
    ///  <para>Reference : </para>
    /// <para><see href="https://fomantic-ui.com/elements/text.html">https://fomantic-ui.com/elements/text.html</see></para>
    /// </remarks>
    ///-------------------------------------------------------------------------------------------------

    public abstract class HeaderBase : FomanticComponentWithContentBase,
        IFomanticComponentWithColor,
        IFomanticComponentCanBeDisabled,
        IAttachableFomanticComponent,
        IFomanticComponentCanBeUnselectable,
        IFomanticComponentWithInvertedStyle,
        IFomanticComponentWithAlignment,
        IFomanticComponentWithContentAlignment,
        IFomanticComponentWithDividingStyle
    {


        /// <inheritdoc/>
        protected internal override void ConstractClasses()
        {           
           
            base.ConstractClasses();
            CssClasses.Insert(0, "ui");
            CssClasses.Add("header");
        }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#disabled"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsDisabled { get; set; } = false;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#colored"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public Color? Color { get; set; } = null;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#inverted"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsInverted { get; set; } = false;

        /// <inheritdoc/>
        [Parameter]
        public bool IsUnselectable { get; set; } = false;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#floating"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public FloatAlignment? Alignment { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#text-alignmentg"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public ContentAlignment? ContentAlignment { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Determinte header type which oriented to give some importance of a section in the context of
        /// the content that surrounds it.
        /// </summary>
        ///
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#page-headers"></see></para>
        /// </remarks>
        ///
        /// <value> The type. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public HeaderType Type { get; set; } = HeaderType.Content;

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#dividing"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsDividing { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#attached"></see></para>
        /// </remarks>
        ///
        /// <inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public AttachingDirection? Attaching { get; set; }
    }
}
