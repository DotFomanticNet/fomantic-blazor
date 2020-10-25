namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithAlignmentFeature : UIFeatureDefinition<IFomanticComponentWithAlignment>
    {
        /// <summary>   class given to Left Float. </summary>
        const string LeftFloatedClass = "left floated";
        /// <summary>   class given to Right Float. </summary>
        const string RightFloatedClass = "right floated";

        public override string ProvideCssClass(IFomanticComponentWithAlignment component)
        {
            return ToClass(component.Alignment);
        }

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
