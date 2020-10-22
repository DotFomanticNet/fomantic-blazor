using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Implementation Responsible for Viewport Visibility tracking
    /// </summary>
    public class ViewportVisibility : IDisposable
    {
        internal Func<ElementReference> ElementToSubscripeFunc { get; }
        internal IJSRuntime JsRuntime { get; }

        /// <summary>
        /// Current View Port Calculations
        /// </summary>
        public IViewPortCalculation Calculation { get; private set; } = new ViewPortCalculation();


        /// <summary>
        /// Create new Viewport Visibility
        /// </summary>
        /// <param name="elementToSubscripeFunc">function to get element to track Visibility</param>
        /// <param name="jsRuntime">js run time to execute javascript interops</param>
        public ViewportVisibility(Func<ElementReference> elementToSubscripeFunc, IJSRuntime jsRuntime)
        {
            ElementToSubscripeFunc = elementToSubscripeFunc;
            JsRuntime = jsRuntime;

        }
        private ElementReference? Element { get; set; }
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
        internal event ViewportVisibilityUpdate OnVisibilityUpdated;

        /// <summary>
        /// Method executed by Javascript to trigger Visibility Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnUpdate(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnVisibilityUpdated != null)
            {
                OnVisibilityUpdated?.Invoke(eventArgs);
            }
           // Console.WriteLine("Visibility Updated");
        }

        /// <summary>
        /// Method determine if visibility updated event Subscribed or not
        /// </summary>
        /// <returns>whether visibility updated event Subscribed or not</returns>
        [JSInvokable]
        public bool UpdateSubscribed()
        {
            return OnVisibilityUpdated != null;
        }
        #endregion

        #region OnTopVisible
        internal event ViewportVisibilityUpdate OnTopVisibleUpdated;

        /// <summary>
        /// Method executed by Javascript to trigger On Top Visible Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnTopVisible(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnTopVisibleUpdated != null)
            {
                OnTopVisibleUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Top Visible updated event Subscribed or not
        /// </summary>
        /// <returns>whether On Top Visible updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnTopVisibleSubscribed()
        {
            return OnTopVisibleUpdated != null;
        }
        #endregion

        #region OnTopPassed
        internal event ViewportVisibilityUpdate OnTopPassedUpdated;

        /// <summary>
        /// Method executed by Javascript to trigger On Top Passed Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnTopPassed(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnTopPassedUpdated != null)
            {
                OnTopPassedUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Top Passed updated event Subscribed or not
        /// </summary>
        /// <returns>whether On Top Passed updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnTopPassedSubscribed()
        {
            return OnTopPassedUpdated != null;
        }


        #endregion

        #region OnBottomVisible
        internal event ViewportVisibilityUpdate OnBottomVisibleUpdated;

        /// <summary>
        /// Method executed by Javascript to trigger On Bottom Visible Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnBottomVisible(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnBottomVisibleUpdated != null)
            {
                OnBottomVisibleUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Bottom Visible updated event Subscribed or not
        /// </summary>
        /// <returns>whether  On Bottom Visible updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnBottomVisibleSubscribed()
        {
            return OnBottomVisibleUpdated != null;
        }


        #endregion

        #region OnPassing
        internal event ViewportVisibilityUpdate OnPassingUpdated;
        /// <summary>
        /// Method executed by Javascript to trigger On Passing Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnPassing(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnPassingUpdated != null)
            {
                OnPassingUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Passing updated event Subscribed or not
        /// </summary>
        /// <returns>whether On Passing updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnPassingSubscribed()
        {
            return OnPassingUpdated != null;
        }


        #endregion

        #region OnBottomPassed
        internal event ViewportVisibilityUpdate OnBottomPassedUpdated;
        /// <summary>
        /// Method executed by Javascript to trigger On Bottom Passed Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnBottomPassed(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnBottomPassedUpdated != null)
            {
                OnBottomPassedUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Bottom Passed updated event Subscribed or not
        /// </summary>
        /// <returns>whether On Bottom Passed updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnBottomPassedSubscribed()
        {
            return OnBottomPassedUpdated != null;
        }


        #endregion

        #region OnTopVisibleReverse
        internal event ViewportVisibilityUpdate OnTopVisibleReverseUpdated;
        /// <summary>
        /// Method executed by Javascript to trigger On TopVisibl Reverse Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnTopVisibleReverse(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnTopVisibleReverseUpdated != null)
            {
                OnTopVisibleReverseUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Top Visible Reverse updated event Subscribed or not
        /// </summary>
        /// <returns>whether On Top Visible Reverse updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnTopVisibleReverseSubscribed()
        {
            return OnTopVisibleReverseUpdated != null;
        }


        #endregion

        #region OnTopPassedReverse
        internal event ViewportVisibilityUpdate OnTopPassedReverseUpdated;
        /// <summary>
        /// Method executed by Javascript to trigger On Top Passed Reverse Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnTopPassedReverse(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnTopPassedReverseUpdated != null)
            {
                OnTopPassedReverseUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Top Passed Reverse updated event Subscribed or not
        /// </summary>
        /// <returns>whether  On Top Passed Reverse updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnTopPassedReverseSubscribed()
        {
            return OnTopPassedReverseUpdated != null;
        }


        #endregion

        #region OnBottomVisibleReverse
        internal event ViewportVisibilityUpdate OnBottomVisibleReverseUpdated;
        /// <summary>
        /// Method executed by Javascript to trigger On Bottom Visible Reverse Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnBottomVisibleReverse(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnBottomVisibleReverseUpdated != null)
            {
                OnBottomVisibleReverseUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Bottom Visible Reverse updated event Subscribed or not
        /// </summary>
        /// <returns>whether On Bottom Visible Reverse updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnBottomVisibleReverseSubscribed()
        {
            return OnBottomVisibleReverseUpdated != null;
        }


        #endregion

        #region OnPassingReverse
        internal event ViewportVisibilityUpdate OnPassingReverseUpdated;
        /// <summary>
        /// Method executed by Javascript to trigger On Passing Reverse Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnPassingReverse(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnPassingReverseUpdated != null)
            {
                OnPassingReverseUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Passing Reverse updated event Subscribed or not
        /// </summary>
        /// <returns>whether  On Passing Reverse updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnPassingReverseSubscribed()
        {
            return OnPassingReverseUpdated != null;
        }


        #endregion

        #region OnBottomPassedReverse
        internal event ViewportVisibilityUpdate OnBottomPassedReverseUpdated;
        /// <summary>
        /// Method executed by Javascript to trigger On Bottom Passed Reverse Updated events
        /// </summary>
        /// <param name="calculation">new calculation after update</param>
        [JSInvokable]
        public  void OnBottomPassedReverse(IViewPortCalculation calculation)
        {
            Calculation = calculation;
            var eventArgs = new ViewPortEventArgs(calculation);

            if (OnBottomPassedReverseUpdated != null)
            {
                OnBottomPassedReverseUpdated?.Invoke(eventArgs);
            }
        }
        /// <summary>
        /// Method determine if On Bottom Passed Reverse updated event Subscribed or not
        /// </summary>
        /// <returns>whether  On Bottom Passed Reverse updated event Subscribed or not</returns>
        [JSInvokable]
        public bool OnBottomPassedReverseSubscribed()
        {
            return OnBottomPassedReverseUpdated != null;
        }


        #endregion
        ///<inheritdoc/>
        public async void Dispose()
        {
            if (Element.HasValue)
            {
                await JsRuntime.InvokeVoidAsync("window.element.destroyVisibilityEvents", Element.Value);
            }
        }
    }
}
