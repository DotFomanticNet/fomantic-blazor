///-------------------------------------------------------------------------------------------------
/// <file>  Fomantic.Blazor.UI\Features\Base\IFeatureDefinition.cs </file>
///
/// <copyright file="IFeatureDefinition.cs" company="MyCompany.com">
/// Copyright (c) 2020 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>   Declares the IFeatureDefinition interface. </summary>
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI.Features
{
    /// <summary>   Interface for feature definition. </summary>
    interface IFeatureDefinition
    {


        ValueTask DisposeAsync(IFomanticComponent component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the type. </summary>
        ///
        /// <value> The type. </value>
        ///-------------------------------------------------------------------------------------------------

        Type Type { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'after each render' action. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A ValueTask&lt;bool&gt; </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask<bool> OnAfterEachRender(IFomanticComponent component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'after first render' action. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A ValueTask&lt;bool&gt; </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask<bool> OnAfterFirstRender(IFomanticComponent component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'initialized' action. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A ValueTask. </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask OnInitialized(IFomanticComponent component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Provide CSS classes. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A string[]. </returns>
        ///-------------------------------------------------------------------------------------------------

        string[] ProvideCssClasses(IFomanticComponent component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Provide CSS class. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A string. </returns>
        ///-------------------------------------------------------------------------------------------------

        string ProvideCssClass(IFomanticComponent component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the additional fragment. </summary>
        ///
        /// <value> The additional fragment. </value>
        ///-------------------------------------------------------------------------------------------------

        IEnumerable<KeyValuePair<string, RenderFragment>> AdditionalFragment { get; }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for feature definition. </summary>
    ///
    /// <typeparam name="TFeatureInterface">    Type of the feature interface. </typeparam>
    ///-------------------------------------------------------------------------------------------------

    interface IFeatureDefinition<TFeatureInterface> : IFeatureDefinition where TFeatureInterface : IFomanticComponent
    {

        ValueTask DisposeAsync(TFeatureInterface component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'after each render' action. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A ValueTask&lt;bool&gt; </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask<bool> OnAfterEachRender(TFeatureInterface component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'after first render' action. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A ValueTask&lt;bool&gt; </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask<bool> OnAfterFirstRender(TFeatureInterface component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'initialized' action. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A ValueTask. </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask OnInitialized(TFeatureInterface component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Provide CSS classes. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A string[]. </returns>
        ///-------------------------------------------------------------------------------------------------

        string[] ProvideCssClasses(TFeatureInterface component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Provide CSS class. </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   A string. </returns>
        ///-------------------------------------------------------------------------------------------------

        string ProvideCssClass(TFeatureInterface component);

    }
}
