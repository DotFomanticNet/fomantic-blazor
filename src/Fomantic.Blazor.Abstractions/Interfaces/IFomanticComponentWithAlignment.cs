///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithAlignment.cs
//
// summary:	Declares the IFomanticComponentWithAlignment interface
///-------------------------------------------------------------------------------------------------

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that can be align to its parent.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticComponentWithAlignment : IFomanticComponentWithClass
    {
    

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine how the component should align to its parent. </summary>
        ///
        /// <value> The alignment. </value>
        ///-------------------------------------------------------------------------------------------------

        public FloatAlignment? Alignment { get; set; }
       
    }
}
