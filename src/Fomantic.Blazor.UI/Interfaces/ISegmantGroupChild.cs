using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Base interface for all fomantic component that has parent segmant group
    /// </summary>
    public interface ISegmantGroupChild : IFomanticGroupComponentChild<SegmentGroup>
    {
       
    }
}
