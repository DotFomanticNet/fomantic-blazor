using Microsoft.AspNetCore.Components.Forms;
using Fomantic.Blazor.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base class for all Fomantic Input Component. </summary>
    public abstract partial class FomanticInputBase<T> : InputBase<T>,
        IFomanticComponentWithJQuery,
        IVisibleFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Return  display name. </summary>
        ///
        /// <returns>
        /// display name.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------
        protected string GetDisplayName()
        {
            if (string.IsNullOrWhiteSpace(DisplayName))
            {
                return FieldIdentifier.FieldName;
            }
            return DisplayName;

        }

        [Inject]
        FeaturesService FeaturesService { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Return the Component Attributes. </summary>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the root element attributes in this
        /// collection.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        protected virtual IEnumerable<KeyValuePair<string, object>> GetRootElementAttributes()
        {
            return InputAttributes.GetRootElementAttributes();
        }


        #region Members


        /// <summary>   The CSS class. </summary>
        private string _cssClass;


        /// <summary>   The input attributes. </summary>
        private Dictionary<string, object> inputAttributes = new Dictionary<string, object>();
        #endregion

        #region Events



        ///-------------------------------------------------------------------------------------------------
        ///<inheritdoc/>
        ///-------------------------------------------------------------------------------------------------

        public event ElementClassChanged OnClassChangedEvent;

        #endregion

        #region Props
        /// <inheritdoc/>
        [Inject]
        public IJSRuntime JsRuntime { get; private set; }


        /// <inheritdoc/>
        public IJSObjectReference JQueryElementRef { get; private set; }
        IJSObjectReference IFomanticComponentWithJQuery.JQueryElementRef { get => JQueryElementRef; set => JQueryElementRef = value; }

        /// <inheritdoc/>
        public ElementReference RootElement { get; protected set; }

        /// <inheritdoc/>
        public List<IFomanticExtension> Extensions { get; private set; } = new List<IFomanticExtension>();

        /// <inheritdoc/>
        protected string GetCssClass(string element = "")
        {
            ConstractClasses();
            if (string.IsNullOrEmpty(element))
            {
                var newCssClass = string.Join(" ", CssClasses.Where(d => !string.IsNullOrEmpty(d)));
                newCssClass += base.CssClass;
                if (_cssClass != newCssClass)
                {
                    ExecuteOnClassChangedEvent(_cssClass, newCssClass);
                    _cssClass = newCssClass;
                }
                return _cssClass;
            }
            else
            {
                var newCssClass = string.Empty;
                if (ElementsCssClasses.ContainsKey(element))
                {
                    newCssClass = string.Join(" ", ElementsCssClasses[element].Where(d => !string.IsNullOrEmpty(d)));
                }
                return newCssClass;
            }

        }
        string IFomanticComponentWithClass.GetCssClass(string element)
        {
            return GetCssClass(element);
        }




        #endregion

        #region overrides
        /// <summary>   Used to add inherited components classes. </summary>
        internal protected virtual void ConstractClasses()
        {
            CssClasses = new List<string>();
            ElementsCssClasses = new Dictionary<string, List<string>>();

            CssClasses.AddRange(FeaturesService.OnConstractClasses(this));

            var fieldCssClasses = new List<string>();

            fieldCssClasses.Add("field");
            if (this.EditContext.IsModified(this.FieldIdentifier))
            {
                fieldCssClasses.Add("modified");
            }
            if (this.EditContext.GetValidationMessages(this.FieldIdentifier).Any())
            {
                fieldCssClasses.Add("error");
            }
            ElementsCssClasses.Add("field", fieldCssClasses);


            if (InputAttributes.ContainsKey("class"))
            {
                CssClasses.Add(InputAttributes["class"].ToString());
            }

        }
        /// <inheritdoc/>
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await FeaturesService.OnInitialized(this);
        }

        /// <inheritdoc/>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            var shouldRerender = false;
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                shouldRerender = await FeaturesService.OnAfterFirstRender(this);

                foreach (var extension in Extensions)
                {
                    extension.ParentStateHasChanged = () => StateHasChanged();
                }

            }
            shouldRerender = shouldRerender || await FeaturesService.OnAfterEachRender(this);


            if (shouldRerender)
            {
                this.StateHasChanged();
            }
        }

        private ValidationMessageStore ValidationMessageStore;
        private EditContext PreviousEditContext = null;
        /// <inheritdoc/>
        protected async override Task OnParametersSetAsync()
        {

            await base.OnParametersSetAsync();

            if (EditContext != PreviousEditContext)
                EditContextChanged();

        }

        private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
        {
            var f = e.FieldIdentifier;

            if (f.Equals(FieldIdentifier))
            {
                await ValidateAsync();
            }

        }
        private async void EditContext_OnValidationRequested(object sender, ValidationRequestedEventArgs args)
        {
            await ValidateAsync();
        }
        /// <summary>
        /// Validate The Field
        /// </summary>
        /// <returns></returns>
        public async Task ValidateAsync()
        {
            ValidationMessageStore.Clear(FieldIdentifier);
            //call extrenal validate awaitable
            AddValidationError($"Error be in {GetDisplayName()}");
            EditContext.NotifyValidationStateChanged();
        }
        void AddValidationError(string error)
        {
            ValidationMessageStore.Add(FieldIdentifier, error);
        }
       
        #endregion

        #region Parameters

        /// <inheritdoc/>
        public Dictionary<string, object> Attributes { get; protected set; } = new Dictionary<string, object>();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   List of all arbitrary attributes. </summary>
        ///
        /// <value> The input attributes. </value>
        ///-------------------------------------------------------------------------------------------------

        //  [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get => inputAttributes.Union(Attributes).ToDictionary(pair => pair.Key, pair => pair.Value); set => inputAttributes = value; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassed { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisible { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassing { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassed { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisibleReverse { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassedReverse { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisibleReverse { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassingReverse { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassedReverse { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnViewportVisibilityChange { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisible { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public EventCallback<ParamterChangedArgs<string>> OnClassChanged { get; set; }


        /// <inheritdoc/>
        [Parameter]
        public bool IsHidden { get; set; }




        /// <inheritdoc/>
        protected List<string> CssClasses { get; set; } = new List<string>();



        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the CSS classes. </summary>
        ///
        /// <value> The CSS classes. </value>
        ///-------------------------------------------------------------------------------------------------

        List<string> IFomanticComponentWithClass.CssClasses { get => CssClasses; }
        /// <summary>   True if is enter animation played, false if not. </summary>


        /// <inheritdoc/>
        public List<ComponentFragment> AdditionalFragments { get; set; } = new List<ComponentFragment>();

        /// <inheritdoc/>
        public Dictionary<string, List<string>> ElementsCssClasses { get; set; } = new Dictionary<string, List<string>>();




        #endregion

        #region Methods

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the on class changed event operation. </summary>
        ///
        /// <param name="oldClass">     The old class. </param>
        /// <param name="currentClass"> The current class. </param>
        ///-------------------------------------------------------------------------------------------------

        async void ExecuteOnClassChangedEvent(string oldClass, string currentClass)
        {
            if (OnClassChangedEvent != null)
            {
                OnClassChangedEvent.Invoke(oldClass, currentClass);
            }
            if (OnClassChanged.HasDelegate)
            {
                await OnClassChanged.InvokeAsync(new ParamterChangedArgs<string>(oldClass, currentClass));
            }
        }




        #endregion

        #region Public Methods
        /// <inheritdoc/>
        [ComponentAction]
        public void Show()
        {
            IsHidden = false;
            StateHasChanged();
        }
        /// <inheritdoc/>
        [ComponentAction]
        public void Hide()
        {
            IsHidden = true;
            StateHasChanged();
        }
        /// <inheritdoc/>
        [ComponentAction]
        public void ToggleVisibility()
        {

            IsHidden = !IsHidden;
            StateHasChanged();
        }
        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await FeaturesService.DisposeAsync(this);

        }











        #endregion

        void EditContextChanged()
        {
            PreviousEditContext = EditContext;
            ValidationMessageStore = new ValidationMessageStore(EditContext);
            this.EditContext.OnValidationRequested += EditContext_OnValidationRequested;
            this.EditContext.OnFieldChanged += EditContext_OnFieldChanged;
        }
    }
}
