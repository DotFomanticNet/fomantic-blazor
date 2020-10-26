using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithExtensionsFeature : UIFeatureDefinition<IFomanticComponentWithExtensions>
    {
        public async override ValueTask<bool> OnAfterFirstRender(IFomanticComponentWithExtensions component)
        {
           var shouldRerender = await base.OnAfterFirstRender(component);

            foreach (var extension in component.Extensions)
            {
                
                shouldRerender = shouldRerender || await extension.OnComponentAfterFirstRender();
            }
            return shouldRerender;
        }

        public async override ValueTask<bool> OnAfterEachRender(IFomanticComponentWithExtensions component)
        {
            var shouldRerender = await base.OnAfterEachRender(component);
            foreach (var extension in component.Extensions)
            {
                shouldRerender = shouldRerender || await extension.OnComponentAfterEachRender();
            }
            return shouldRerender;
        }
        public override string[] ProvideCssClasses(IFomanticComponentWithExtensions component)
        {
            var cssClasses = new List<string>();
            foreach (var extension in component.Extensions)
            {
                cssClasses.AddRange(extension.ProvideComponentCssClasses());
                cssClasses.Add(extension.ProvideComponentCssClass());
            }
            return cssClasses.ToArray();
        } 
    }
}
