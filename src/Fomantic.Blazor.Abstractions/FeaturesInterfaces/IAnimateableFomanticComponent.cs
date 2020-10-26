///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IVisibleBlazorComponent.cs
//
// summary:	Declares the IVisibleBlazorComponent interface
///-------------------------------------------------------------------------------------------------


namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that can be animated
    /// </summary>
    ///
    ///-------------------------------------------------------------------------------------------------
    public interface IAnimateableFomanticComponent : IVisibleFomanticComponent, IFomanticComponentWithExtensions
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Animator responsible for animating the component. </summary>
        ///
        /// <value> The animator. </value>
        ///-------------------------------------------------------------------------------------------------

        [NestedParamter]
        public IFomanticAnimator Animator { get; }
    }
}
