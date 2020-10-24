using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Base class for all Fomantic Component
    /// </summary>
    public abstract class FomanticComponentBase : ComponentBase,
        IFomanticComponentWithJQuery,
        IVisibleFomanticComponent,
        IFomanticComponentWithEnterTransition,
        IFomanticComponentWithClass
    {
        /// <summary>
        /// Return the Component Attributes
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<KeyValuePair<string, object>> GetRootElementAttributes()
        {
            return InputAttributes.GetMainElementAttributes();
        }


        #region Members
        private Lazy<FomanticComponentAnimator<FomanticComponentBase>> lazyAnimator;
        private Lazy<ViewportVisibility> lazyViewportVisibility;
        private string _cssClass;
        private bool isEnterAnimationPlayed = false;
        private Dictionary<string, object> inputAttributes = new Dictionary<string, object>();
        #endregion

        #region Events
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnViewportVisibilityChangeEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnTopVisibleEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnTopPassedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnBottomVisibleEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnPassingEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnBottomPassedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnTopVisibleReverseEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnTopPassedReverseEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnBottomVisibleReverseEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnPassingReverseEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnBottomPassedReverseEvent;
        ///<inheritdoc/>
        public event ElementClassChanged OnClassChangedEvent;

        #endregion

        #region Props
        ///<inheritdoc/>
        [Inject]
        public IJSRuntime JsRuntime { get; private set; }


        ///<inheritdoc/>
        public IJSObjectReference JQueryElementRef { get; private set; }
        ///<inheritdoc/>
        public ElementReference RootElement { get; protected set; }

        ///<inheritdoc/>
        public List<IFomanticComponentExtension> Extensions { get; private set; }

        ///<inheritdoc/>
        [NestedParamter]
        public IFomanticAnimator Animator => lazyAnimator.Value;

        /// <summary>
        ///  Object responsible for Viewport Visibility tracking
        /// </summary>
        [NestedParamter]
        public ViewportVisibility ViewportVisibility => lazyViewportVisibility.Value;

        ///<inheritdoc/>
        public string CssClass
        {
            get
            {
                ConstractClasses();
                var newCssClass = string.Join(" ", CssClasses.Where(d=>!string.IsNullOrEmpty(d)));
               
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
        /// <summary>
        /// Used to add inherited components classes 
        /// </summary>
        internal protected virtual void ConstractClasses()
        {
            CssClasses = new List<string>();
            this.UpdateComponentFeaturesClasses();
            if (InputAttributes.ContainsKey("class"))
            {
                CssClasses.Add(InputAttributes["class"].ToString());
            }

        }
        ///<inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (EnterTransition.HasValue)
            {
                IsHidden = true;
            }

            this.UpdateComponentFeaturesAfterRender();

        }
        ///<inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                lazyAnimator = new Lazy<FomanticComponentAnimator<FomanticComponentBase>>(() => new FomanticComponentAnimator<FomanticComponentBase>(this));

                lazyViewportVisibility = new Lazy<ViewportVisibility>(() =>
                {
                    var x = new ViewportVisibility(() => RootElement, JsRuntime);

                    #region Viewport Visibility Events
                    if (OnViewportVisibilityChangeEvent != null)
                    {
                        x.OnVisibilityUpdated += OnViewportVisibilityChangeEvent;

                    }
                    if (OnViewportVisibilityChange.HasDelegate)
                    {
                        x.OnVisibilityUpdated += d => OnViewportVisibilityChange.InvokeAsync(d);
                    }

                    if (OnTopVisibleEvent != null)
                    {
                        x.OnTopVisibleUpdated += OnTopVisibleEvent;
                    }
                    if (OnTopVisible.HasDelegate)
                    {
                        x.OnTopVisibleUpdated += d => OnTopVisible.InvokeAsync(d);
                    }

                    if (OnTopPassedEvent != null)
                    {
                        x.OnTopPassedUpdated += OnTopPassedEvent;
                    }
                    if (OnTopPassed.HasDelegate)
                    {
                        x.OnTopPassedUpdated += d => OnTopPassed.InvokeAsync(d);
                    }

                    if (OnBottomVisibleEvent != null)
                    {
                        x.OnBottomVisibleUpdated += OnBottomVisibleEvent;
                    }
                    if (OnBottomVisible.HasDelegate)
                    {
                        x.OnBottomVisibleUpdated += d => OnBottomVisible.InvokeAsync(d);
                    }

                    if (OnPassingEvent != null)
                    {
                        x.OnPassingUpdated += OnPassingEvent;
                    }
                    if (OnPassing.HasDelegate)
                    {
                        x.OnPassingUpdated += d => OnPassing.InvokeAsync(d);
                    }

                    if (OnBottomPassedEvent != null)
                    {
                        x.OnBottomPassedUpdated += OnBottomPassedEvent;
                    }
                    if (OnBottomPassed.HasDelegate)
                    {
                        x.OnBottomPassedUpdated += d => OnBottomPassed.InvokeAsync(d);
                    }

                    if (OnTopVisibleReverseEvent != null)
                    {
                        x.OnTopVisibleReverseUpdated += OnTopVisibleReverseEvent;
                    }
                    if (OnTopVisibleReverse.HasDelegate)
                    {
                        x.OnTopVisibleReverseUpdated += d => OnTopVisibleReverse.InvokeAsync(d);
                    }


                    if (OnTopPassedReverseEvent != null)
                    {
                        x.OnTopPassedReverseUpdated += OnTopPassedReverseEvent;
                    }
                    if (OnTopPassedReverse.HasDelegate)
                    {
                        x.OnTopPassedReverseUpdated += d => OnTopPassedReverse.InvokeAsync(d);
                    }


                    if (OnBottomVisibleReverseEvent != null)
                    {
                        x.OnBottomVisibleReverseUpdated += OnBottomVisibleReverseEvent;
                    }
                    if (OnBottomVisibleReverse.HasDelegate)
                    {
                        x.OnBottomVisibleReverseUpdated += d => OnBottomVisibleReverse.InvokeAsync(d);
                    }


                    if (OnPassingReverseEvent != null)
                    {
                        x.OnPassingReverseUpdated += OnPassingReverseEvent;
                    }
                    if (OnPassingReverse.HasDelegate)
                    {
                        x.OnPassingReverseUpdated += d => OnPassingReverse.InvokeAsync(d);
                    }

                    if (OnBottomPassedReverseEvent != null)
                    {
                        x.OnBottomPassedReverseUpdated += OnBottomPassedReverseEvent;
                    }
                    if (OnBottomPassedReverse.HasDelegate)
                    {
                        x.OnBottomPassedReverseUpdated += d => OnBottomPassedReverse.InvokeAsync(d);
                    }


                    #endregion

                    x.Apply();
                    return x;
                });
            }

            this.UpdateComponentFeaturesAfterRender();

        }
        ///<inheritdoc/>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                JQueryElementRef = await JsRuntime.InvokeAsync<IJSObjectReference>("$", RootElement);
                //if (EnterTransition.HasValue )//to do add paramter
                //{
                //    ViewportVisibility.Apply();
                //    OnTopVisibilityEvent += async d =>
                //    {
                //        Console.WriteLine("Should Play Animation");
                //        if (!isEnterAnimationPlayed)
                //        {
                //            await Animator.AnimatedShow(EnterTransition.Value, EnterTransitionDuration);
                //            isEnterAnimationPlayed = true;
                //        }
                //    };
                //}
                //else 
                if (EnterTransition.HasValue)
                {

                    if (!isEnterAnimationPlayed)
                    {
                        await Animator.AnimatedShow(EnterTransition.Value, EnterTransitionDuration);
                        isEnterAnimationPlayed = true;
                    }

                }
            }

        }

        #endregion

        #region Parameters

        ///<inheritdoc/>
        public Dictionary<string, object> Attributes { get; protected set; } = new Dictionary<string, object>();
        /// <summary>
        /// List of all arbitrary attributes
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get => inputAttributes.Union(Attributes).ToDictionary(pair => pair.Key, pair => pair.Value); set => inputAttributes = value; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassed { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisible { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassing { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassed { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisibleReverse { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassedReverse { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisibleReverse { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassingReverse { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassedReverse { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnViewportVisibilityChange { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisible { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ParamterChangedArgs<string>> OnClassChanged { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public TransitionAnimation? EnterTransition { get; set; }

        ///<inheritdoc/>
        [Parameter]
        public bool IsHidden { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public int EnterTransitionDuration { get; set; }



        ///<inheritdoc/>
        protected List<string> CssClasses { get; set; } = new List<string>();
        List<string> IFomanticComponentWithClass.CssClasses { get => CssClasses; }

        #endregion

        #region Methods



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
        ///<inheritdoc/>
        [ComponentAction]
        public void Show()
        {
            // await JsRuntime.InvokeVoidAsync("window.element.show", RootElement);
            IsHidden = false;
        }
        ///<inheritdoc/>
        [ComponentAction]
        public void Hide()
        {
            //   await JsRuntime.InvokeVoidAsync("window.element.hide", RootElement);
            IsHidden = true;
        }
        ///<inheritdoc/>
        [ComponentAction]
        public void ToggleVisibility()
        {
            //  await JsRuntime.InvokeVoidAsync("window.element.toggleVisibility", RootElement);
            IsHidden = !IsHidden;
        }
        ///<inheritdoc/>
        public void Dispose()
        {
            if (lazyAnimator.IsValueCreated)
            {
                lazyAnimator.Value.Dispose();
            }
            if (lazyViewportVisibility.IsValueCreated)
            {
                lazyViewportVisibility.Value.Dispose();
            }
            GC.SuppressFinalize(this);
        }








        #endregion

    }
}
