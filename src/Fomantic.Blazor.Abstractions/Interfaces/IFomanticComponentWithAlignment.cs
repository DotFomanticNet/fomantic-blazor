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
        /// <summary>   class given to Left Float. </summary>
        const string LeftFloatedClass = "left floated";
        /// <summary>   class given to Right Float. </summary>
        const string RightFloatedClass = "right floated";

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine how the component should align to its parent. </summary>
        ///
        /// <value> The alignment. </value>
        ///-------------------------------------------------------------------------------------------------

        public FloatAlignment? Alignment { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="FloatAlignment"/> to given class. </summary>
        ///
        /// <param name="alignment">    Alignment Value. </param>
        ///
        /// <returns>   given class from <paramref name="alignment"/> </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToClass(FloatAlignment? alignment)
        {
            if (!alignment.HasValue)
            {
                return string.Empty;
            }
            return alignment switch
            {
                FloatAlignment.Right => RightFloatedClass,
                FloatAlignment.Left => LeftFloatedClass,
                _ => string.Empty,
            };
        }
    }
}
