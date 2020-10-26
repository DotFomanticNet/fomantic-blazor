///-------------------------------------------------------------------------------------------------
// file:	FomanticBase\ViewportVisibility\ViewportVisibility.cs
//
// summary:	Implements the viewport visibility class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Implementation Responsible for Viewport Visibility tracking. </summary>
    public class ViewportVisibility : IViewportVisibility
    {




        Action IFomanticExtension.ParentStateHasChanged { get; set; }
        IFomanticComponentWithExtensions IFomanticExtension.Parent { get; set; }

        List<ComponentFragment> IFomanticExtension.ComponentAdditionalFragments { get; }


        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the js runtime. </summary>
        ///
        /// <value> The js runtime. </value>
        ///-------------------------------------------------------------------------------------------------

        internal IJSRuntime JsRuntime { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Current View Port Calculations. </summary>
        ///
        /// <value> The calculation. </value>
        ///-------------------------------------------------------------------------------------------------

        public ViewPortCalculation Calculation { get; private set; } = new ViewPortCalculation();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the element. </summary>
        ///
        /// <value> The element. </value>
        ///-------------------------------------------------------------------------------------------------

        private ElementReference? Element { get => (this as IFomanticExtension)?.Parent?.RootElement; }
        /// <summary>   Applies this.  </summary>
        internal async void Apply()
        {
            var parent = (this as IFomanticExtension).Parent as IVisibleFomanticComponent;
            if (Element != null)
            {
                #region Viewport Visibility Events

                if (parent.OnViewportVisibilityChange.HasDelegate)
                {
                    OnVisibilityUpdated += d => parent.OnViewportVisibilityChange.InvokeAsync(d);
                }


                if (parent.OnTopVisible.HasDelegate)
                {
                    OnTopVisibleUpdated += d => parent.OnTopVisible.InvokeAsync(d);
                }


                if (parent.OnTopPassed.HasDelegate)
                {
                    OnTopPassedUpdated += d => parent.OnTopPassed.InvokeAsync(d);
                }


                if (parent.OnBottomVisible.HasDelegate)
                {
                    OnBottomVisibleUpdated += d => parent.OnBottomVisible.InvokeAsync(d);
                }


                if (parent.OnPassing.HasDelegate)
                {
                    OnPassingUpdated += d => parent.OnPassing.InvokeAsync(d);
                }


                if (parent.OnBottomPassed.HasDelegate)
                {
                    OnBottomPassedUpdated += d => parent.OnBottomPassed.InvokeAsync(d);
                }


                if (parent.OnTopVisibleReverse.HasDelegate)
                {
                    OnTopVisibleReverseUpdated += d => parent.OnTopVisibleReverse.InvokeAsync(d);
                }



                if (parent.OnTopPassedReverse.HasDelegate)
                {
                    OnTopPassedReverseUpdated += d => parent.OnTopPassedReverse.InvokeAsync(d);
                }



                if (parent.OnBottomVisibleReverse.HasDelegate)
                {
                    OnBottomVisibleReverseUpdated += d => parent.OnBottomVisibleReverse.InvokeAsync(d);
                }



                if (parent.OnPassingReverse.HasDelegate)
                {
                    OnPassingReverseUpdated += d => parent.OnPassingReverse.InvokeAsync(d);
                }


                if (parent.OnBottomPassedReverse.HasDelegate)
                {
                    OnBottomPassedReverseUpdated += d => parent.OnBottomPassedReverse.InvokeAsync(d);
                }


                #endregion


                await JsRuntime.InvokeVoidAsync("window.element.initVisibilityEvents",
                Element,
                DotNetObjectReference.Create(this)
                );
            }
        }

        /// <summary>
        /// Create a ViewportVisibility Component
        /// </summary>
        /// <param name="parentCompoent"></param>
        public ViewportVisibility(IFomanticComponentWithExtensions parentCompoent)
        {
            (this as IFomanticExtension).Parent = parentCompoent;
            JsRuntime = parentCompoent?.JsRuntime;

        }
        object objectLock;
        event ViewportVisibilityUpdate IViewportVisibility.OnTopVisibleUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnTopVisibleUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnTopVisibleUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnTopPassedUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnTopPassedUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnTopPassedUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnBottomVisibleUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnBottomVisibleUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnBottomVisibleUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnPassingUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnPassingUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnPassingUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnBottomPassedUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnBottomPassedUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnBottomPassedUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnTopVisibleReverseUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnTopVisibleReverseUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnTopVisibleReverseUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnTopPassedReverseUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnTopPassedReverseUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnTopPassedReverseUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnBottomVisibleReverseUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnBottomVisibleReverseUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnBottomVisibleReverseUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnPassingReverseUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnPassingReverseUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnPassingReverseUpdated -= value;
                }
            }
        }

        event ViewportVisibilityUpdate IViewportVisibility.OnBottomPassedReverseUpdated
        {
            add
            {
                lock (objectLock)
                {
                    OnBottomPassedReverseUpdated += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    OnBottomPassedReverseUpdated -= value;
                }
            }
        }

      




        #region OnUpdate
        /// <summary>   Event queue for all listeners interested in OnVisibilityUpdated events. </summary>
        event ViewportVisibilityUpdate OnVisibilityUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger Visibility Updated events. </summary>
        ///       
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnUpdate()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnVisibilityUpdated != null)
            {
                OnVisibilityUpdated?.Invoke(eventArgs);
            }

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method determine if visibility updated event Subscribed or not. </summary>
        ///
        /// <returns>   whether visibility updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool UpdateSubscribed()
        {
            return OnVisibilityUpdated != null;
        }
        #endregion

        #region OnTopVisible
        /// <summary>   Event queue for all listeners interested in OnTopVisibleUpdated events. </summary>
        event ViewportVisibilityUpdate OnTopVisibleUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Top Visible Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnTopVisible()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnTopVisibleUpdated != null)
            {
                OnTopVisibleUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method determine if On Top Visible updated event Subscribed or not. </summary>
        ///
        /// <returns>   whether On Top Visible updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnTopVisibleSubscribed()
        {
            return OnTopVisibleUpdated != null;
        }
        #endregion

        #region OnTopPassed
        /// <summary>   Event queue for all listeners interested in OnTopPassedUpdated events. </summary>
        event ViewportVisibilityUpdate OnTopPassedUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Top Passed Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnTopPassed()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnTopPassedUpdated != null)
            {
                OnTopPassedUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method determine if On Top Passed updated event Subscribed or not. </summary>
        ///
        /// <returns>   whether On Top Passed updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnTopPassedSubscribed()
        {
            return OnTopPassedUpdated != null;
        }


        #endregion

        #region OnBottomVisible
        /// <summary>   Event queue for all listeners interested in OnBottomVisibleUpdated events. </summary>
        event ViewportVisibilityUpdate OnBottomVisibleUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Bottom Visible Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnBottomVisible()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnBottomVisibleUpdated != null)
            {
                OnBottomVisibleUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method determine if On Bottom Visible updated event Subscribed or not. </summary>
        ///
        /// <returns>   whether  On Bottom Visible updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnBottomVisibleSubscribed()
        {
            return OnBottomVisibleUpdated != null;
        }


        #endregion

        #region OnPassing
        /// <summary>   Event queue for all listeners interested in OnPassingUpdated events. </summary>
        event ViewportVisibilityUpdate OnPassingUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Passing Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnPassing()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnPassingUpdated != null)
            {
                OnPassingUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method determine if On Passing updated event Subscribed or not. </summary>
        ///
        /// <returns>   whether On Passing updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnPassingSubscribed()
        {
            return OnPassingUpdated != null;
        }


        #endregion

        #region OnBottomPassed
        /// <summary>   Event queue for all listeners interested in OnBottomPassedUpdated events. </summary>
        event ViewportVisibilityUpdate OnBottomPassedUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Bottom Passed Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnBottomPassed()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnBottomPassedUpdated != null)
            {
                OnBottomPassedUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method determine if On Bottom Passed updated event Subscribed or not. </summary>
        ///
        /// <returns>   whether On Bottom Passed updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnBottomPassedSubscribed()
        {
            return OnBottomPassedUpdated != null;
        }


        #endregion

        #region OnTopVisibleReverse

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnTopVisibleReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event ViewportVisibilityUpdate OnTopVisibleReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On TopVisibl Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnTopVisibleReverse()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnTopVisibleReverseUpdated != null)
            {
                OnTopVisibleReverseUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method determine if On Top Visible Reverse updated event Subscribed or not.
        /// </summary>
        ///
        /// <returns>   whether On Top Visible Reverse updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnTopVisibleReverseSubscribed()
        {
            return OnTopVisibleReverseUpdated != null;
        }


        #endregion

        #region OnTopPassedReverse

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnTopPassedReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event ViewportVisibilityUpdate OnTopPassedReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On Top Passed Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnTopPassedReverse()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnTopPassedReverseUpdated != null)
            {
                OnTopPassedReverseUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method determine if On Top Passed Reverse updated event Subscribed or not. </summary>
        ///
        /// <returns>   whether  On Top Passed Reverse updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnTopPassedReverseSubscribed()
        {
            return OnTopPassedReverseUpdated != null;
        }


        #endregion

        #region OnBottomVisibleReverse

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnBottomVisibleReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event ViewportVisibilityUpdate OnBottomVisibleReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On Bottom Visible Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnBottomVisibleReverse()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnBottomVisibleReverseUpdated != null)
            {
                OnBottomVisibleReverseUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method determine if On Bottom Visible Reverse updated event Subscribed or not.
        /// </summary>
        ///
        /// <returns>   whether On Bottom Visible Reverse updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnBottomVisibleReverseSubscribed()
        {
            return OnBottomVisibleReverseUpdated != null;
        }


        #endregion

        #region OnPassingReverse

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnPassingReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event ViewportVisibilityUpdate OnPassingReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On Passing Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnPassingReverse()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnPassingReverseUpdated != null)
            {
                OnPassingReverseUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method determine if On Passing Reverse updated event Subscribed or not. </summary>
        ///
        /// <returns>   whether  On Passing Reverse updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnPassingReverseSubscribed()
        {
            return OnPassingReverseUpdated != null;
        }


        #endregion

        #region OnBottomPassedReverse

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event queue for all listeners interested in OnBottomPassedReverseUpdated events.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------

        event ViewportVisibilityUpdate OnBottomPassedReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On Bottom Passed Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public void OnBottomPassedReverse()
        {

            var eventArgs = new ViewPortEventArgs(Calculation);

            if (OnBottomPassedReverseUpdated != null)
            {
                OnBottomPassedReverseUpdated?.Invoke(eventArgs);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method determine if On Bottom Passed Reverse updated event Subscribed or not.
        /// </summary>
        ///
        /// <returns>   whether  On Bottom Passed Reverse updated event Subscribed or not. </returns>
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public bool OnBottomPassedReverseSubscribed()
        {
            return OnBottomPassedReverseUpdated != null;
        }


        #endregion


        async ValueTask<bool> IFomanticExtension.OnComponentAfterEachRender()
        {
            return false;
        }

        async ValueTask<bool> IFomanticExtension.OnComponentAfterFirstRender()
        {
            return false;
        }

        async ValueTask IFomanticExtension.OnComponentInitialized()
        {

        }

        string[] IFomanticExtension.ProvideComponentCssClasses()
        {
            return Array.Empty<string>();
        }

        string IFomanticExtension.ProvideComponentCssClass()
        {
            return string.Empty;
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (Element.HasValue)
            {
                await JsRuntime.InvokeVoidAsync("window.element.destroyVisibilityEvents", Element.Value);
            }
        }
    }
}
