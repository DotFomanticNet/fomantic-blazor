namespace Fomantic.Blazor.UI.Features
{
    class FomanticDimmerWithShadeDegreeFeature : UIFeatureDefinition<IFomanticDimmerWithShadeDegree>
    {
        /// <summary>   class given to make dimmer dark shaded. </summary>
        public static string DarkShadeClass = "";
        /// <summary>   class given to make dimmer medium shaded. </summary>
        public static string MediumShadeClass = "medium";
        /// <summary>   class given to make dimmer light shaded. </summary>
        public static string LightShadeClass = "light";
        /// <summary>   class given to make dimmer very light shaded. </summary>
        public static string VeryLightShadeClass = "very light";

        public override string ProvideCssClass(IFomanticDimmerWithShadeDegree component)
        {
            return ToClass(component.Shade);
        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.DimmerShade"/> to given class. </summary>
        ///
        /// <param name="shade"> Dimmer shade value. </param>
        ///
        /// <returns>   Given class from <paramref name="shade"/> </returns>
        ///-------------------------------------------------------------------------------------------------
        public static string ToClass(DimmerShade? shade)
        {
            if (!shade.HasValue)
            {
                return string.Empty;
            }
            return shade.Value switch
            {
                DimmerShade.Dark => DarkShadeClass,
                DimmerShade.Medium => MediumShadeClass,
                DimmerShade.Light => LightShadeClass,
                DimmerShade.VeryLight => VeryLightShadeClass,
                _ => string.Empty,
            };
        }
    }
}
