///-------------------------------------------------------------------------------------------------
// file:	EventArgs\ElementClassChangedArgs.cs
//
// summary:	Implements the element class changed arguments class
///-------------------------------------------------------------------------------------------------

using System;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Delegate of Element Class Change Event. </summary>
    ///
    /// <param name="oldClass">     The old value of css class. </param>
    /// <param name="currentClass"> The new value of css class. </param>
    ///-------------------------------------------------------------------------------------------------

    public delegate void ElementClassChanged(string oldClass, string currentClass);

}
