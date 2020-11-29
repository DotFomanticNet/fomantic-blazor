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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fomantic
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An extention sample. </summary>
    ///
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase"/>
    /// <seealso cref="Fomantic.Blazor.UI.IFomanticComponentExtension"/>
    /// <seealso cref="IFomanticComponentExtension"/>
    ///-------------------------------------------------------------------------------------------------

    public partial class ExtensionBase : FomanticComponentBase, IFomanticComponentExtension
    {
        /// <inheritdoc/>
        protected async override Task OnInitializedAsync()
        {
            await this.OnComponentInitialized();
            await base.OnInitializedAsync();
        }
        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            if (Parent != null)
            {
                var parentType = Parent.GetType();
                if (AllowedParentTypes != null && AllowedParentTypes.Any())
                {

                    if (!AllowedParentTypes.Any(d => d.IsAssignableFrom(parentType)))
                    {
                        if (AllowedParentTypes.Count() == 1)
                        {
                            throw new Exception($"{this.GetType().Name} parent must be only of type {AllowedParentTypes.FirstOrDefault().Name}");
                        }
                        else
                        {
                            throw new Exception($"{this.GetType().Name} parent must be only one of types {string.Join(",", AllowedParentTypes.Select(d => d.Name))}");
                        }
                    }
                }
                if (IsUnique && Parent.Extensions.Any(d => d.GetType().IsAssignableFrom(GetType())))
                {

                    throw new Exception($"{this.GetType().Name} only allowed once in {parentType.Name}");
                }
                Parent.Extensions.Add(this);

            }
            else
            {
                if (!IsParentOptional)
                {
                    if (AllowedParentTypes != null && !AllowedParentTypes.Any())
                    {
                        throw new Exception($"{this.GetType().Name} must have any parent inherits from IFomanticComponent");
                    }
                    else
                    {
                        if (AllowedParentTypes.Count() == 1)
                        {
                            throw new Exception($"{this.GetType().Name} must have a parent of type {AllowedParentTypes.FirstOrDefault().Name}");
                        }
                        else
                        {
                            throw new Exception($"{this.GetType().Name} must have any parent of type  {string.Join(",", AllowedParentTypes.Select(d => d.Name))}");
                        }

                    }

                }
            }
           
            base.OnInitialized();
        }
        /// <inheritdoc/>
        [CascadingParameter(Name = "Parent")]
        public IFomanticComponentWithExtensions Parent { get; set; }

        /// <inheritdoc/>
        public List<ComponentFragment> ComponentAdditionalFragments { get; set; } = new List<ComponentFragment>();



        /// <inheritdoc/>
        public virtual async ValueTask<bool> OnComponentAfterEachRender()
        {
           
            return false;
        }
        /// <summary>   True if has render once, false if not. </summary>
        bool hasRenderOnce = true;
        /// <inheritdoc/>
        public virtual async ValueTask<bool> OnComponentAfterFirstRender()
        {
            var _hasRenderOnce = hasRenderOnce;
            hasRenderOnce = false;
           
            return _hasRenderOnce;
        }

        /// <inheritdoc/>
        public virtual async ValueTask OnComponentInitialized()
        {
           
        }

        /// <inheritdoc/>
        public virtual string ProvideComponentCssClass()
        {
            return string.Empty;
        }

        /// <inheritdoc/>
        public virtual string[] ProvideComponentCssClasses()
        {
            return Array.Empty<string>();
        }


        /// <inheritdoc/>
        public Action ParentStateHasChanged { get; set; }

        /// <inheritdoc/>
        public virtual IEnumerable<Type> AllowedParentTypes => new List<Type>();

        /// <inheritdoc/>
        public virtual bool IsParentOptional { get => false; }
        /// <inheritdoc/>
        public virtual bool IsUnique { get => false; }
        IFomanticComponent IFomanticComponentWithParent.Parent { get => Parent; set => Parent = (IFomanticComponentWithExtensions)value; }
    }
}
