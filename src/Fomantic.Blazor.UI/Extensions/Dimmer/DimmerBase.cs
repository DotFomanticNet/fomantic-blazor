using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomantic.Blazor.UI.Features;
using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// A dimmer hides distractions to focus attention on particular content
    /// <para><see href="https://fomantic-ui.com/modules/dimmer.html"></see></para>
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public abstract class DimmerBase : ExtensionWithContentBase,
        IFomanticComponentWithVerticalContentAlignment,
        IFomanticComponentWithBlurEffect,
        IFomanticComponentWithInvertedStyle,
        IFomanticDimmerWithShadeDegree

    {
        
        /// <inheritdoc/>
        [Parameter]
        public ContentVerticalAlignment? ContentVerticalAlignment { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public bool IsBlurring { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public bool IsInverted { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public DimmerShade? Shade { get; set; }

        /// <summary>
        /// Create new instant of DimmerBase
        /// </summary>
        public DimmerBase()
        {
            IsHidden = true;
        }


        /// <inheritdoc/>  
        protected internal override void ConstractClasses()
        {
            base.ConstractClasses();

            CssClasses.Insert(0, "ui simple");
            CssClasses.Add("dimmer");
        }

        /// <inheritdoc/>  
        public override string ProvideComponentCssClass()
        {
            if (IsHidden)
            {
                return string.Empty;
            }
            else
            {
                var cssclass = "dimmable dimmed ";
                if (IsBlurring)
                {
                    cssclass += FomanticComponentWithBlurEffectFeature.BlurringClass;
                }
                return cssclass;
            }
            

        }
    }
}
