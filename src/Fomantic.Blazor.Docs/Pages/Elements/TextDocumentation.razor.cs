using Fomantic.Blazor.Docs.Shared;

using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fomantic.Blazor.Docs.Pages.Elements
{
    public partial class TextDocumentation
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            TextStyleSampleData.Add(new SampleComponentWithHtmlContent<Text>(null, d => d.IsBold = true) { Content = "Bold text here <br><br>" });
            TextStyleSampleData.Add(new SampleComponentWithHtmlContent<Text>(null, d => d.IsItalic = true) { Content = "Italic text here <br><br>" });
            TextStyleSampleData.Add(new SampleComponentWithHtmlContent<Text>(null, d => d.TextDecoration = UI.TextDecoration.LineThrough) { Content = "Line goes through this text here <br><br>" });
            TextStyleSampleData.Add(new SampleComponentWithHtmlContent<Text>(null, d => d.TextDecoration = UI.TextDecoration.OverLine) { Content = "Line goes over this text here <br><br>" });
            TextStyleSampleData.Add(new SampleComponentWithHtmlContent<Text>(null, d => d.TextDecoration = UI.TextDecoration.UnderLine) { Content = "Line goes under this text here <br><br>" });
            TextStyleSampleData.Add(new SampleComponentWithHtmlContent<Text>(null, d => d.TextDecoration = UI.TextDecoration.UnderLineOverline) { Content = "Line goes under and over this text here<br><br>" });
        }
    }

}

