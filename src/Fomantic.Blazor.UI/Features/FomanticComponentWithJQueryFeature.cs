using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithJQueryFeature : UIFeatureDefinition<IFomanticComponentWithJQuery>
    {
        public async override ValueTask<bool> OnAfterFirstRender(IFomanticComponentWithJQuery component)
        {
            component.JQueryElementRef = await component.JsRuntime.InvokeAsync<IJSObjectReference>("$", component.RootElement);
            return false;
        }
    }
}
