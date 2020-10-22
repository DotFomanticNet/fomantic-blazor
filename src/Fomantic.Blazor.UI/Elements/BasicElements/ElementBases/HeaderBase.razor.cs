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
    /// A text is used to style some inline text with a simple color
    /// </summary>
    ///  <remarks>
    ///  <para>Reference : </para>
    /// <para><see href="https://fomantic-ui.com/elements/text.html">https://fomantic-ui.com/elements/text.html</see></para>
    /// </remarks>
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


        ///<inheritdoc/>
        protected internal override void ConstractClasses()
        {
            base.ConstractClasses();
            CssClasses.Insert(0, "ui");
            this.AddDisabledClass(1)
                .AddAlignmentClass(1)
                .AddContentAlignmentClass(1)
                .AddAttachClass(1)
                .AddDividingClass(1)
                .AddUnselectableClass(1)
                .AddInvertedClass(1)
                .AddColorClass(1);
            CssClasses.Add("header");
        }





        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#disabled"></see></para>
        /// </remarks>
        [Parameter]
        public bool IsDisabled { get; set; } = false;


        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#colored"></see></para>
        /// </remarks>
        [Parameter]
        public Color? Color { get; set; } = null;

        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#inverted"></see></para>
        /// </remarks>
        [Parameter]
        public bool IsInverted { get; set; } = false;

        ///<inheritdoc/>
        [Parameter]
        public bool IsUnselectable { get; set; } = false;

        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#floating"></see></para>
        /// </remarks>
        [Parameter]
        public FloatAlignment? Alignment { get; set; }

        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#text-alignmentg"></see></para>
        /// </remarks>
        [Parameter]
        public ContentAlignment? ContentAlignment { get; set; }

        /// <summary>
        /// Determinte header type which oriented to give some importance of a section in the context of the content that surrounds it
        /// </summary>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#page-headers"></see></para>
        /// </remarks>
        [Parameter]
        public HeaderType Type { get; set; } = HeaderType.Content;

        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#dividing"></see></para>
        /// </remarks>    
        [Parameter]
        public bool IsDividing { get; set; }


        ///<inheritdoc/>
        /// <remarks> 
        /// <para>References : </para>
        /// <para><see href="https://fomantic-ui.com/elements/header.html#attached"></see></para>
        /// </remarks>
        [Parameter]
        public AttachingDirection? Attaching { get; set; }
    }
}
