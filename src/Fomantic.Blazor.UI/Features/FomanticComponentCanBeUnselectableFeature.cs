using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentCanBeUnselectableFeature : UIFeatureDefinition<IFomanticComponentCanBeUnselectable>
    {

    }
    class VisibleFomanticComponentFeature : UIFeatureDefinition<IVisibleFomanticComponent>
    {
        /// <summary>   class given to the component to invert its color. </summary>
        const string HiddenClass = "transition hidden";

        public override string ProvideCssClass(IVisibleFomanticComponent component)
        {
            if (component.IsHidden)
            {
                return HiddenClass;
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
