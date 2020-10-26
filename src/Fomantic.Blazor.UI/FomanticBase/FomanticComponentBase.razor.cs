
using Fomantic.Blazor.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base class for all Fomantic Component. </summary>
    public abstract partial class FomanticComponentBase : ComponentBase,
        IFomanticComponentWithJQuery,
        IFomanticComponentWithExtensions,
        IVisibleFomanticComponent,
        IFomanticComponentWithEnterTransition,
        IFomanticComponentWithClass
    {
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
        [NestedParamter]
        public IFomanticAnimator Animator => (IFomanticAnimator)Extensions.FirstOrDefault(d => d is FomanticComponentAnimator<IAnimateableFomanticComponent>);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Object responsible for Viewport Visibility tracking. </summary>
        ///
        /// <value> The viewport visibility. </value>
        ///-------------------------------------------------------------------------------------------------

        [NestedParamter]
        public IViewportVisibility ViewportVisibility => (IViewportVisibility)Extensions.FirstOrDefault(d => d is IViewportVisibility);
        /// <inheritdoc/>
        public string CssClass
        {
            get
            {
                ConstractClasses();
                var newCssClass = string.Join(" ", CssClasses.Where(d => !string.IsNullOrEmpty(d)));

                if (_cssClass != newCssClass)
                {
                    ExecuteOnClassChangedEvent(_cssClass, newCssClass);
                    _cssClass = newCssClass;
                }
                return _cssClass;
            }

        }
        #endregion

        #region overrides
        /// <summary>   Used to add inherited components classes. </summary>
        internal protected virtual void ConstractClasses()
        {
            CssClasses = new List<string>();
            CssClasses.AddRange(FeaturesService.OnConstractClasses(this));
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
                shouldRerender = shouldRerender || await FeaturesService.OnAfterFirstRender(this);

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

        #endregion

        #region Parameters

        /// <inheritdoc/>
        public Dictionary<string, object> Attributes { get; protected set; } = new Dictionary<string, object>();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   List of all arbitrary attributes. </summary>
        ///
        /// <value> The input attributes. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter(CaptureUnmatchedValues = true)]
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
        public TransitionAnimation? EnterTransition { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public bool IsHidden { get; set; }
        /// <inheritdoc/>
        [Parameter]
        public int EnterTransitionDuration { get; set; }



        /// <inheritdoc/>
        protected List<string> CssClasses { get; set; } = new List<string>();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the CSS classes. </summary>
        ///
        /// <value> The CSS classes. </value>
        ///-------------------------------------------------------------------------------------------------

        List<string> IFomanticComponentWithClass.CssClasses { get => CssClasses; }
        /// <summary>   True if is enter animation played, false if not. </summary>
        bool IFomanticComponentWithEnterTransition.IsEnterAnimationDone { get; set; }
        /// <inheritdoc/>
        public List<ComponentFragment> AdditionalFragments { get; set; } = new List<ComponentFragment>();




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
            // await JsRuntime.InvokeVoidAsync("window.element.show", RootElement);
            IsHidden = false;
        }
        /// <inheritdoc/>
        [ComponentAction]
        public void Hide()
        {
            //   await JsRuntime.InvokeVoidAsync("window.element.hide", RootElement);
            IsHidden = true;
        }
        /// <inheritdoc/>
        [ComponentAction]
        public void ToggleVisibility()
        {
            //  await JsRuntime.InvokeVoidAsync("window.element.toggleVisibility", RootElement);
            IsHidden = !IsHidden;
        }
        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await FeaturesService.DisposeAsync(this);

        }








        #endregion

    }
}
