using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Base interface for all fomantic component that has animatable children component
    /// </summary>
    /// <typeparam name="TChild">The parent component type</typeparam>
    public interface IFomanticGroupComponentWithAnimatableChildren<TChild> : IFomanticGroupComponent<TChild> where TChild : IFomanticComponent
    {
        /// <summary>
        /// Animator responsible for animating the children components
        /// </summary>
        public IFomanticAnimator ChildrenAnimator { get; }
    }
}
    