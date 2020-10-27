using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        IFomanticComponentCanBeDisabled
    {
        /// <inheritdoc/>       
        [Parameter]
        public bool IsDisabled { get; set; } = true;


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
            if (IsDisabled)
            {
                return string.Empty;
            }
            else
            {
                return "dimmable dimmed";
            }

        }
    }
}
