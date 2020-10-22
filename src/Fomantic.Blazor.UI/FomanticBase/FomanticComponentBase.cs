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
        public event ViewportVisibilityUpdate OnViewportVisibilityUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnTopVisibilityUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnTopPassedUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnBottomVisibleUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnPassingUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnBottomPassedUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnTopVisibleReverseUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnTopPassedReverseUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnBottomVisibleReverseUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnPassingReverseUpdatedEvent;
        ///<inheritdoc/>
        public event ViewportVisibilityUpdate OnBottomPassedReverseUpdatedEvent;
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
                var newCssClass = string.Join(" ", CssClasses);
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
            this.AddHiddenClass();
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
                    if (OnViewportVisibilityUpdatedEvent != null)
                    {
                        x.OnVisibilityUpdated += OnViewportVisibilityUpdatedEvent;

                    }
                    if (OnViewportVisibilityUpdated.HasDelegate)
                    {
                        x.OnVisibilityUpdated += d => OnViewportVisibilityUpdated.InvokeAsync(d);
                    }

                    if (OnTopVisibilityUpdatedEvent != null)
                    {
                        x.OnTopVisibleUpdated += OnTopVisibilityUpdatedEvent;
                    }
                    if (OnTopVisibilityUpdated.HasDelegate)
                    {
                        x.OnTopVisibleUpdated += d => OnTopVisibilityUpdated.InvokeAsync(d);
                    }

                    if (OnTopPassedUpdatedEvent != null)
                    {
                        x.OnTopPassedUpdated += OnTopPassedUpdatedEvent;
                    }
                    if (OnTopPassedUpdated.HasDelegate)
                    {
                        x.OnTopPassedUpdated += d => OnTopPassedUpdated.InvokeAsync(d);
                    }

                    if (OnBottomVisibleUpdatedEvent != null)
                    {
                        x.OnBottomVisibleUpdated += OnBottomVisibleUpdatedEvent;
                    }
                    if (OnBottomVisibleUpdated.HasDelegate)
                    {
                        x.OnBottomVisibleUpdated += d => OnBottomVisibleUpdated.InvokeAsync(d);
                    }

                    if (OnPassingUpdatedEvent != null)
                    {
                        x.OnPassingUpdated += OnPassingUpdatedEvent;
                    }
                    if (OnPassingUpdated.HasDelegate)
                    {
                        x.OnPassingUpdated += d => OnPassingUpdated.InvokeAsync(d);
                    }

                    if (OnBottomPassedUpdatedEvent != null)
                    {
                        x.OnBottomPassedUpdated += OnBottomPassedUpdatedEvent;
                    }
                    if (OnBottomPassedUpdated.HasDelegate)
                    {
                        x.OnBottomPassedUpdated += d => OnBottomPassedUpdated.InvokeAsync(d);
                    }

                    if (OnTopVisibleReverseUpdatedEvent != null)
                    {
                        x.OnTopVisibleReverseUpdated += OnTopVisibleReverseUpdatedEvent;
                    }
                    if (OnTopVisibleReverseUpdated.HasDelegate)
                    {
                        x.OnTopVisibleReverseUpdated += d => OnTopVisibleReverseUpdated.InvokeAsync(d);
                    }


                    if (OnTopPassedReverseUpdatedEvent != null)
                    {
                        x.OnTopPassedReverseUpdated += OnTopPassedReverseUpdatedEvent;
                    }
                    if (OnTopPassedReverseUpdated.HasDelegate)
                    {
                        x.OnTopPassedReverseUpdated += d => OnTopPassedReverseUpdated.InvokeAsync(d);
                    }


                    if (OnBottomVisibleReverseUpdatedEvent != null)
                    {
                        x.OnBottomVisibleReverseUpdated += OnBottomVisibleReverseUpdatedEvent;
                    }
                    if (OnBottomVisibleReverseUpdated.HasDelegate)
                    {
                        x.OnBottomVisibleReverseUpdated += d => OnBottomVisibleReverseUpdated.InvokeAsync(d);
                    }


                    if (OnPassingReverseUpdatedEvent != null)
                    {
                        x.OnPassingReverseUpdated += OnPassingReverseUpdatedEvent;
                    }
                    if (OnPassingReverseUpdated.HasDelegate)
                    {
                        x.OnPassingReverseUpdated += d => OnPassingReverseUpdated.InvokeAsync(d);
                    }

                    if (OnBottomPassedReverseUpdatedEvent != null)
                    {
                        x.OnBottomPassedReverseUpdated += OnBottomPassedReverseUpdatedEvent;
                    }
                    if (OnBottomPassedReverseUpdated.HasDelegate)
                    {
                        x.OnBottomPassedReverseUpdated += d => OnBottomPassedReverseUpdated.InvokeAsync(d);
                    }


                    #endregion

                    x.Apply();
                    return x;
                });
            }



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
                //    OnTopVisibilityUpdatedEvent += async d =>
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
        public EventCallback<ViewPortEventArgs> OnTopPassedUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisibleUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassingUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassedUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisibleReverseUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopPassedReverseUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomVisibleReverseUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnPassingReverseUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnBottomPassedReverseUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnViewportVisibilityUpdated { get; set; }
        ///<inheritdoc/>
        [Parameter]
        public EventCallback<ViewPortEventArgs> OnTopVisibilityUpdated { get; set; }
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
