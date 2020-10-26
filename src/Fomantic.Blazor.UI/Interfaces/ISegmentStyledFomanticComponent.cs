///-------------------------------------------------------------------------------------------------
// file:	Interfaces\ISegmentStyledFomanticComponent.cs
//
// summary:	Declares the ISegmentStyledFomanticComponent interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all Fomantic Blazor Segment Components that can be be in different segment
    /// style.  
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface ISegmentStyledFomanticComponent : IFomanticComponentWithClass
    {
     

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine how the segment should be styled. </summary>
        ///
        /// <value> The segment style. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public SegmentStyle SegmentStyle { get; set; }


       
    }
}
