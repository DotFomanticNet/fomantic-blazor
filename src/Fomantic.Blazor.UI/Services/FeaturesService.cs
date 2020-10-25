using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomantic.Blazor.UI.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Fomantic.Blazor.UI.Services
{
    class FeaturesService
    {
        List<IFeatureDefinition> Features { get; set; } = new List<IFeatureDefinition>();
        IServiceProvider ServiceProvider { get; set; }
        public FeaturesService(IServiceProvider services)
        {

            ServiceProvider = services;

            var allFeatureTypes = GetAllFeatures();

            foreach (var featureType in allFeatureTypes)
            {

                IFeatureDefinition feature = null;
                if (ServiceProvider != null)
                {
                    feature = ServiceProvider.GetService(featureType) as IFeatureDefinition;

                }
                if (feature == null)
                {
                    feature = Activator.CreateInstance(featureType) as IFeatureDefinition;

                }
                Features.Add(feature);
            }
        }

        public List<Type> GetAllFeatures()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                 .Where(x => typeof(IFeatureDefinition).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .ToList();
        }

        public async ValueTask DisposeAsync(IFomanticComponent component)
        {

            foreach (var feature in Features)
            {
                if (feature.Type.IsAssignableFrom(component.GetType()))
                {
                    await feature.DisposeAsync(component);
                }
            }

        }

        public async ValueTask<bool> OnAfterEachRender(IFomanticComponent component)
        {
            bool result = false;
            foreach (var feature in Features)
            {
                if (feature.Type.IsAssignableFrom(component.GetType()))
                {
                    result = result || await feature.OnAfterEachRender(component);
                }
            }
            return result;
        }
        public async ValueTask<bool> OnAfterFirstRender(IFomanticComponent component)
        {
            bool result = false;
            foreach (var feature in Features)
            {
                if (feature.Type.IsAssignableFrom(component.GetType()))
                {
                    result = result || await feature.OnAfterFirstRender(component);
                }
            }
            return result;
        }
        public async ValueTask OnInitialized(IFomanticComponent component)
        {
            foreach (var feature in Features)
            {
                if (feature.Type.IsAssignableFrom(component.GetType()))
                {
                    await feature.OnInitialized(component);
                }
            }
        }
        public List<string> OnConstractClasses(IFomanticComponent component)
        {
            List<string> result = new List<string>();
            foreach (var feature in Features)
            {

                if (feature.Type.IsAssignableFrom(component.GetType()))
                {
                    result.AddRange(feature.ProvideCssClasses(component));
                    result.Add(feature.ProvideCssClass(component));
                }

            }
            return result;
        }

    }
}
