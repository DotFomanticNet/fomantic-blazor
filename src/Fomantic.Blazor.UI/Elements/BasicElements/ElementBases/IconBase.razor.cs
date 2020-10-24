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

    /// <summary>
    /// An icon is a glyph used to represent something else
    /// </summary>
    ///  <remarks>
    ///  <para>Reference : </para>
    /// <para><see href="https://fomantic-ui.com/elements/icon.html">https://fomantic-ui.com/elements/icon.html</see></para>
    /// </remarks>
    public abstract class IconBase : FomanticComponentBase,
        IFomanticComponentWithColor,
        IFomanticComponentWithSize,
        IFomanticComponentCanBeDisabled,
        IFomanticComponentWithInvertedStyle,
        IFomanticComponentWithFittedStyle,
        IFomanticComponentWithCircularStyle


    {
        ///<inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

        }

        ///<inheritdoc/>
        protected internal override void ConstractClasses()
        {

            base.ConstractClasses();
            CssClasses.Add(Icon.ToCssClass());
            CssClasses.Add("icon");
        }

        ///<inheritdoc/>
        /// <remarks>
        /// A circular segment will most likely have to have its content manually sized to be equal width and height, otherwise it will flow to the size of your content.
        /// <para>Reference : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#circular">https://fomantic-ui.com/elements/icon.html#circular</see></para>
        /// </remarks>
        [Parameter]
        public bool IsCircular { get; set; }

        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#size"></see></para>
        /// </remarks>
        [Parameter]
        public Size Size { get; set; } = Size.Medium;

        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#colored"></see></para>
        /// </remarks>
        [Parameter]
        public Color? Color { get; set; } = null;

        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#/icon"></see></para>
        /// </remarks>
        [Parameter]
        public IconList Icon { get; set; }

        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#inverted"></see></para>
        /// </remarks>
        [Parameter]
        public bool IsInverted { get; set; } = false;
        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#disabled"></see></para>
        /// </remarks>
        [Parameter]
        public bool IsDisabled { get; set; } = false;
        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/icon.html#fitted"></see></para>
        /// </remarks>
        [Parameter]
        public bool IsFitted { get; set; }



    }
}
