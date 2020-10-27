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
            var dimmerSampleDataText = new SampleComponentWithHtmlContent<Text>(dimmerSampleDataContainerSegman) { Content = "This content will be dimmed<br>This content will be dimmed<br>This content will be dimmed<br>This content will be dimmed <br>This content will be dimmed  " };
            var dimmerSampleDataDimmer = new SampleComponentWithHtmlContent<Dimmer>(dimmerSampleDataContainerSegman, d => d.IsDisabled = false);

            dimmerSampleDataContainerSegman.InternalComponents.Add(dimmerSampleDataText);
            dimmerSampleDataContainerSegman.InternalComponents.Add(dimmerSampleDataDimmer);
            DimmerSampleData.Add(dimmerSampleDataContainerSegman);
        }
        #endregion DimmerSampleData

        #endregion Types


        protected override void OnInitialized()
        {
            base.OnInitialized();

            CreateDimmerSampleData();
        }


    }
}
