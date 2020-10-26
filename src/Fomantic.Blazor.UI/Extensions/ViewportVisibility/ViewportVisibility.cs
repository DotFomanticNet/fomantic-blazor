///-------------------------------------------------------------------------------------------------
// file:	FomanticBase\ViewportVisibility\ViewportVisibility.cs
//
// summary:	Implements the viewport visibility class
///-------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Implementation Responsible for Viewport Visibility tracking. </summary>
    public class ViewportVisibility : IDisposable
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the element to subscripe function. </summary>
        ///
        /// <value> A function delegate that yields an ElementReference. </value>
        ///-------------------------------------------------------------------------------------------------

        internal Func<ElementReference> ElementToSubscripeFunc { get; }

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
        /// <summary>   Create new Viewport Visibility. </summary>
        ///
        /// <param name="elementToSubscripeFunc">   function to get element to track Visibility. </param>
        /// <param name="jsRuntime">                js run time to execute javascript interops. </param>
        ///-------------------------------------------------------------------------------------------------

        public ViewportVisibility(Func<ElementReference> elementToSubscripeFunc, IJSRuntime jsRuntime)
        {
            ElementToSubscripeFunc = elementToSubscripeFunc;
            JsRuntime = jsRuntime;

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the element. </summary>
        ///
        /// <value> The element. </value>
        ///-------------------------------------------------------------------------------------------------

        private ElementReference? Element { get; set; }
        /// <summary>   Applies this.  </summary>
        internal async void Apply()
        {
            Element = ElementToSubscripeFunc?.Invoke();
            if (Element != null)
            {
                await JsRuntime.InvokeVoidAsync("window.element.initVisibilityEvents",
                Element,
                DotNetObjectReference.Create(this)
                );
            }
        }


        #region OnUpdate
        /// <summary>   Event queue for all listeners interested in OnVisibilityUpdated events. </summary>
        internal event ViewportVisibilityUpdate OnVisibilityUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger Visibility Updated events. </summary>
        ///       
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnUpdate()
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
        internal event ViewportVisibilityUpdate OnTopVisibleUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Top Visible Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnTopVisible()
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
        internal event ViewportVisibilityUpdate OnTopPassedUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Top Passed Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnTopPassed()
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
        internal event ViewportVisibilityUpdate OnBottomVisibleUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Bottom Visible Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnBottomVisible()
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
        internal event ViewportVisibilityUpdate OnPassingUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Passing Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnPassing()
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
        internal event ViewportVisibilityUpdate OnBottomPassedUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Method executed by Javascript to trigger On Bottom Passed Updated events. </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnBottomPassed()
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

        internal event ViewportVisibilityUpdate OnTopVisibleReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On TopVisibl Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnTopVisibleReverse()
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

        internal event ViewportVisibilityUpdate OnTopPassedReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On Top Passed Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnTopPassedReverse()
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

        internal event ViewportVisibilityUpdate OnBottomVisibleReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On Bottom Visible Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnBottomVisibleReverse()
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

        internal event ViewportVisibilityUpdate OnPassingReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On Passing Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnPassingReverse()
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

        internal event ViewportVisibilityUpdate OnBottomPassedReverseUpdated;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method executed by Javascript to trigger On Bottom Passed Reverse Updated events.
        /// </summary>
        ///
        ///-------------------------------------------------------------------------------------------------

        [JSInvokable]
        public  void OnBottomPassedReverse()
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
        /// <inheritdoc/>
        public async void Dispose()
        {
            if (Element.HasValue)
            {
                await JsRuntime.InvokeVoidAsync("window.element.destroyVisibilityEvents", Element.Value);
            }
        }
    }
}
