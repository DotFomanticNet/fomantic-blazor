using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentCanBeDisabledFeature : UIFeatureDefinition<IFomanticComponentCanBeDisabled>
    {
        /// <summary>   class given to disable component. </summary>
        const string DisabledClass = "disabled";


        public override string ProvideCssClass(IFomanticComponentCanBeDisabled component)
        {
            if (component.IsDisabled)
            {
                return DisabledClass;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
