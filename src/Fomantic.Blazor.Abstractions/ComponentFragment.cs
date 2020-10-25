///-------------------------------------------------------------------------------------------------
/// <file>  Fomantic.Blazor.UI\Features\Base\UIFeatureDefinition.cs </file>
///
/// <copyright file="UIFeatureDefinition.cs" company="MyCompany.com">
/// Copyright (c) 2020 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>   Implements the feature definition class. </summary>
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using System;

namespace Fomantic.Blazor.UI
{
    /// <summary>   A component fragment. </summary>
    public class ComponentFragment
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the location. </summary>
        ///
        /// <value> The location. </value>
        ///-------------------------------------------------------------------------------------------------

        public string Location { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the fragment. </summary>
        ///
        /// <value> The fragment. </value>
        ///-------------------------------------------------------------------------------------------------

        public Func<IFomanticComponent, RenderFragment> Fragment { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the order. </summary>
        ///
        /// <value> The order. </value>
        ///-------------------------------------------------------------------------------------------------

        public int Order { get; set; } = 0;
    }
}
