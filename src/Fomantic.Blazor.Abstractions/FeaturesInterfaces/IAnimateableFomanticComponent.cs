// file:	Interfaces\IVisibleBlazorComponent.cs
//
// summary:	Declares the IVisibleBlazorComponent interface


using System.Linq;
///-------------------------------------------------------------------------------------------------
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
        /// <summary>  Get Animator responsible for animating the component. </summary>
        ///
        /// <returns> The animator. </returns>
        ///-------------------------------------------------------------------------------------------------

        public IFomanticAnimator GetAnimator()
        {
          return  (IFomanticAnimator)Extensions.FirstOrDefault(d => d is IFomanticAnimator);
        }
            
            
    }


}
