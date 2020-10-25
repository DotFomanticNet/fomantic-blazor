using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI.Features
{
    public abstract class UIFeatureDefinition<TFeatureInterface> : IFeatureDefinition<TFeatureInterface> where TFeatureInterface : IFomanticComponent
    {
        public IEnumerable<KeyValuePair<string, RenderFragment>> AdditionalFragment { get; set; } = new List<KeyValuePair<string, RenderFragment>>();

        public Type Type => typeof(TFeatureInterface);

        public async virtual ValueTask DisposeAsync(TFeatureInterface component)
        {
            Console.WriteLine($"Dispose for {typeof(TFeatureInterface).Name}");
        }



        public async virtual ValueTask<bool> OnAfterEachRender(TFeatureInterface component)
        {
            Console.WriteLine($"OnAfterEachRender for {typeof(TFeatureInterface).Name}");
            return false;
        }

        public async virtual ValueTask<bool> OnAfterFirstRender(TFeatureInterface component)
        {
            Console.WriteLine($"OnAfterFirstRender for {typeof(TFeatureInterface).Name}");
            return false;
        }

        public virtual string[] ProvideCssClasses(TFeatureInterface component)
        {
            return Array.Empty<string>();
        }
        public virtual string ProvideCssClass(TFeatureInterface component)
        {
            return string.Empty;
        }
        public async virtual ValueTask OnInitialized(TFeatureInterface component)
        {
            Console.WriteLine($"OnInitialized  for {typeof(TFeatureInterface).Name}");
        }

        ValueTask<bool> IFeatureDefinition.OnAfterEachRender(IFomanticComponent component)
        {
            return OnAfterEachRender((TFeatureInterface)component);
        }

        ValueTask<bool> IFeatureDefinition.OnAfterFirstRender(IFomanticComponent component)
        {
            return OnAfterFirstRender((TFeatureInterface)component);
        }

        string[] IFeatureDefinition.ProvideCssClasses(IFomanticComponent component)
        {
            return ProvideCssClasses((TFeatureInterface)component);
        }
        string IFeatureDefinition.ProvideCssClass(IFomanticComponent component)
        {
            return ProvideCssClass((TFeatureInterface)component);
        }
        ValueTask IFeatureDefinition.OnInitialized(IFomanticComponent component)
        {
            return OnInitialized((TFeatureInterface)component);
        }

         ValueTask IFeatureDefinition.DisposeAsync(IFomanticComponent component)
        {
            return DisposeAsync((TFeatureInterface)component);
        }
    }
}
