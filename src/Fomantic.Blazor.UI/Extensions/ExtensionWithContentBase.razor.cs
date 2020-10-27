///-------------------------------------------------------------------------------------------------
/// <file>  Fomantic.Blazor.UI\Extensions\ExtentionSample.razor.cs </file>
///
/// <copyright file="ExtentionSample.razor.cs" company="MyCompany.com">
/// Copyright (c) 2020 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>   Implements the extention sample.razor class. </summary>
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An extention with contentbase . </summary>
    ///
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase"/>
    /// <seealso cref="Fomantic.Blazor.UI.IFomanticComponentExtension"/>
    /// <seealso cref="IFomanticComponentExtension"/>
    ///-------------------------------------------------------------------------------------------------

    public partial class ExtensionWithContentBase : IFomanticComponentWithContent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Content of the extension.   </summary>
        ///
        /// <value> The child content. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
