///-------------------------------------------------------------------------------------------------
// file:	Enums\AttachingDirection.cs
//
// summary:	Implements the attaching direction class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Mark the attachable element type. </summary>
    public enum AttachingDirection
    {
        /// <summary>
        /// Mark this  copmonent as attachable in its group
        /// </summary>
        Middle = 0,
        /// <summary>
        /// Mark this as top/first copmonent in attachable group
        /// </summary>
        Top,
        /// <summary>
        /// Mark this as bottom/last copmonent in attachable group
        /// </summary>
        Bottom
    }
}
