namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithColorFeature : UIFeatureDefinition<IFomanticComponentWithColor>
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.Color"/> to given class. </summary>
        ///
        /// <param name="color">    Color Value. </param>
        ///
        /// <returns>   Given class from <paramref name="color"/> </returns>
        ///-------------------------------------------------------------------------------------------------
        public static string ToClass(Color? color)
        {
            return color?.ToString()?.ToLower() ?? string.Empty;
        }


        public override string ProvideCssClass(IFomanticComponentWithColor component)
        {
           return ToClass(component.Color);
        }
    }

}
