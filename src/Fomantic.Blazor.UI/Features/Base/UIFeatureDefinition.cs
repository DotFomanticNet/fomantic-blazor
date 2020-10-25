///-------------------------------------------------------------------------------------------------
/// <file>  Fomantic.Blazor.UI\Features\Base\UIFeatureDefinition.cs </file>
///
/// <copyright file="UIFeatureDefinition.cs" company="MyCompany.com">
/// Copyright (c) 2020 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>   Implements the feature definition class. </summary>
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI.Features
{

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A feature definition. </summary>
    ///
    /// <typeparam name="TFeatureInterface">    Type of the feature interface. </typeparam>
    ///
    /// <seealso cref="IFeatureDefinition{TFeatureInterface}"/>
    ///-------------------------------------------------------------------------------------------------

    public abstract class UIFeatureDefinition<TFeatureInterface> : IFeatureDefinition<TFeatureInterface> where TFeatureInterface : IFomanticComponent
    {
        /// <inheritdoc/>
        public List<ComponentFragment> AdditionalFragments { get; set; } = new List<ComponentFragment>();

        /// <inheritdoc/>
        public Type Type => typeof(TFeatureInterface);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Dispose asynchronous. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A ValueTask. </returns>
        ///-------------------------------------------------------------------------------------------------

        public async virtual ValueTask DisposeAsync(TFeatureInterface component)
        {
            
        }



        /// <inheritdoc/>
        public async virtual ValueTask<bool> OnAfterEachRender(TFeatureInterface component)
        {
           
            return false;
        }

        /// <inheritdoc/>
        public async virtual ValueTask<bool> OnAfterFirstRender(TFeatureInterface component)
        {
           
            return false;
        }

        /// <inheritdoc/>
        public virtual string[] ProvideCssClasses(TFeatureInterface component)
        {
            return Array.Empty<string>();
        }
        /// <inheritdoc/>
        public virtual string ProvideCssClass(TFeatureInterface component)
        {
            return string.Empty;
        }
        /// <inheritdoc/>
        public async virtual ValueTask OnInitialized(TFeatureInterface component)
        {
            component.AdditionalFragments.AddRange(this.AdditionalFragments);
        }

        /// <inheritdoc/>
        ValueTask<bool> IFeatureDefinition.OnAfterEachRender(IFomanticComponent component)
        {
            return OnAfterEachRender((TFeatureInterface)component);
        }

        /// <inheritdoc/>
        ValueTask<bool> IFeatureDefinition.OnAfterFirstRender(IFomanticComponent component)
        {
            return OnAfterFirstRender((TFeatureInterface)component);
        }

        /// <inheritdoc/>
        string[] IFeatureDefinition.ProvideCssClasses(IFomanticComponent component)
        {
            return ProvideCssClasses((TFeatureInterface)component);
        }
        /// <inheritdoc/>
        string IFeatureDefinition.ProvideCssClass(IFomanticComponent component)
        {
            return ProvideCssClass((TFeatureInterface)component);
        }
        /// <inheritdoc/>
        ValueTask IFeatureDefinition.OnInitialized(IFomanticComponent component)
        {
            return OnInitialized((TFeatureInterface)component);
        }

         ///-------------------------------------------------------------------------------------------------
         /// <summary>  Dispose asynchronous. </summary>
         ///
         /// <param name="component">   The component. </param>
         ///
         /// <returns>  A ValueTask. </returns>
         ///-------------------------------------------------------------------------------------------------

         ValueTask IFeatureDefinition.DisposeAsync(IFomanticComponent component)
        {
            return DisposeAsync((TFeatureInterface)component);
        }
    }
}
