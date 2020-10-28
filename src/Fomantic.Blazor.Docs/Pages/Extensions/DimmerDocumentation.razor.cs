using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fomantic.Blazor.Docs.Shared;

namespace Fomantic.Blazor.Docs.Pages.Extensions
{
    public partial class DimmerDocumentation
    {
        string pageUri = "/extensions/dimmer";

        #region Types

        #region DimmerSampleData
        public List<SampleComponent> DimmerSampleData { get; set; } = new List<SampleComponent>();



        void CreateDimmerSampleData()
        {
            var dimmerSampleDataContainerSegman = new SampleComponentWithChildren<Segment>(null);
            var dimmerSampleDataText = new SampleComponentWithHtmlContent<Text>(dimmerSampleDataContainerSegman) { Content = "<img class=\"ui wireframe image\" src=\"/images/short-paragraph.png\"><img class=\"ui wireframe image\" src=\"/images/short-paragraph.png\"><img class=\"ui wireframe image\" src=\"/images/short-paragraph.png\">" };
            var dimmerSampleDataDimmer = new SampleComponentWithHtmlContent<Dimmer>(dimmerSampleDataContainerSegman, d => d.IsDisabled = false);

            dimmerSampleDataContainerSegman.InternalComponents.Add(dimmerSampleDataText);
            dimmerSampleDataContainerSegman.InternalComponents.Add(dimmerSampleDataDimmer);
            DimmerSampleData.Add(dimmerSampleDataContainerSegman);
        }
        #endregion DimmerSampleData

        #region DimmerWithContentSampleData
        public List<SampleComponent> DimmerWithContentSampleData { get; set; } = new List<SampleComponent>();



        void CreateDimmerWithContentSampleData()
        {
            var dimmerSampleDataContainerSegman = new SampleComponentWithChildren<Segment>(null);
            var dimmerSampleDataText = new SampleComponentWithHtmlContent<Text>(dimmerSampleDataContainerSegman) { Content = "<img class=\"ui wireframe image\" src=\"/images/short-paragraph.png\"><img class=\"ui wireframe image\" src=\"/images/short-paragraph.png\"><img class=\"ui wireframe image\" src=\"/images/short-paragraph.png\">" };
            var dimmerSampleDataDimmer = new SampleComponentWithHtmlContent<Dimmer>(dimmerSampleDataContainerSegman, d => d.IsDisabled = false)
            { Content = " <h2 class=\"ui inverted icon header\"><i class=\"heart icon\"></i>Dimmed Message!</h2>" };

            dimmerSampleDataContainerSegman.InternalComponents.Add(dimmerSampleDataText);
            dimmerSampleDataContainerSegman.InternalComponents.Add(dimmerSampleDataDimmer);
            DimmerWithContentSampleData.Add(dimmerSampleDataContainerSegman);
        }
        #endregion DimmerSampleData

        #endregion Types


        protected override void OnInitialized()
        {
            base.OnInitialized();

            CreateDimmerSampleData();
            CreateDimmerWithContentSampleData();
        }


    }
}
