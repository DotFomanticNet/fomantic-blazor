﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base class for all Fomantic Form Component. </summary>
    /// src : https://github.com/dotnet/aspnetcore/blob/master/src/Components/Web/src/Forms/EditForm.cs
    public abstract partial class FomanticFormBase<T> : ComponentBase
    {
        /// <summary>
        /// Func To handle Submiting form
        /// </summary>
        protected readonly Func<Task> HandleSubmitDelegate; // Cache to avoid per-render allocations

        private EditContext? _editContext;
        private bool _hasSetEditContextExplicitly;

        /// <summary>
        /// Constructs an instance of <see cref="EditForm"/>.
        /// </summary>
        public FomanticFormBase()
        {
            HandleSubmitDelegate = HandleSubmitAsync;
        }

        /// <summary>
        /// Gets or sets a collection of additional attributes that will be applied to the created <c>form</c> element.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>
        /// Supplies the edit context explicitly. If using this parameter, do not
        /// also supply <see cref="Model"/>, since the model value will be taken
        /// from the <see cref="EditContext.Model"/> property.
        /// </summary>
        [Parameter]
        public EditContext? EditContext
        {
            get => _editContext;
            set
            {
                _editContext = value;
                _hasSetEditContextExplicitly = value != null;
            }
        }

        /// <summary>
        /// Specifies the top-level model object for the form. An edit context will
        /// be constructed for this model. If using this parameter, do not also supply
        /// a value for <see cref="EditContext"/>.
        /// </summary>
        [Parameter] public T? Model { get; set; }

        /// <summary>
        /// Specifies the content to be rendered inside this <see cref="EditForm"/>.
        /// </summary>
        [Parameter] public RenderFragment<EditContext>? ChildContent { get; set; }

        /// <summary>
        /// A callback that will be invoked when the form is submitted.
        ///
        /// If using this parameter, you are responsible for triggering any validation
        /// manually, e.g., by calling <see cref="EditContext.Validate"/>.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnSubmit { get; set; }

        /// <summary>
        /// A callback that will be invoked when the form is submitted and the
        /// <see cref="EditContext"/> is determined to be valid.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnValidSubmit { get; set; }

        /// <summary>
        /// A callback that will be invoked when the form is submitted and the
        /// <see cref="EditContext"/> is determined to be invalid.
        /// </summary>
        [Parameter] public EventCallback<EditContext> OnInvalidSubmit { get; set; }



        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            if (_hasSetEditContextExplicitly && Model != null)
            {
                throw new InvalidOperationException($"{nameof(EditForm)} requires a {nameof(Model)} " +
                    $"parameter, or an {nameof(EditContext)} parameter, but not both.");
            }
            else if (!_hasSetEditContextExplicitly && Model == null)
            {
                throw new InvalidOperationException($"{nameof(EditForm)} requires either a {nameof(Model)} " +
                    $"parameter, or an {nameof(EditContext)} parameter, please provide one of these.");
            }

            // If you're using OnSubmit, it becomes your responsibility to trigger validation manually
            // (e.g., so you can display a "pending" state in the UI). In that case you don't want the
            // system to trigger a second validation implicitly, so don't combine it with the simplified
            // OnValidSubmit/OnInvalidSubmit handlers.
            if (OnSubmit.HasDelegate && (OnValidSubmit.HasDelegate || OnInvalidSubmit.HasDelegate))
            {
                throw new InvalidOperationException($"When supplying an {nameof(OnSubmit)} parameter to " +
                    $"{nameof(EditForm)}, do not also supply {nameof(OnValidSubmit)} or {nameof(OnInvalidSubmit)}.");
            }

            // Update _editContext if we don't have one yet, or if they are supplying a
            // potentially new EditContext, or if they are supplying a different Model
            if (Model != null && !Model.Equals(_editContext?.Model))
            {
                _editContext = new EditContext(Model!);
            }
        }

        private async Task HandleSubmitAsync()
        {


            if (OnSubmit.HasDelegate)
            {
                // When using OnSubmit, the developer takes control of the validation lifecycle
                await OnSubmit.InvokeAsync(_editContext);
            }
            else
            {
                // Otherwise, the system implicitly runs validation on form submission
                var isValid = _editContext.Validate(); // This will likely become ValidateAsync later

                if (isValid && OnValidSubmit.HasDelegate)
                {
                    await OnValidSubmit.InvokeAsync(_editContext);
                }

                if (!isValid && OnInvalidSubmit.HasDelegate)
                {
                    await OnInvalidSubmit.InvokeAsync(_editContext);
                }
            }
        }
    }
}
