///-------------------------------------------------------------------------------------------------
// file:	EventArgs\ParamterChangedArgs.cs
//
// summary:	Implements the paramter changed arguments class
///-------------------------------------------------------------------------------------------------

using System;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Arguments for paramter changed. </summary>
    ///
    /// <typeparam name="TValue">   Type of the value. </typeparam>
    ///-------------------------------------------------------------------------------------------------

    public class ParamterChangedArgs<TValue> : EventArgs
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="oldValue"> The old value. </param>
        /// <param name="newValue"> The new value. </param>
        ///-------------------------------------------------------------------------------------------------

        public ParamterChangedArgs(TValue oldValue, TValue newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the old value. </summary>
        ///
        /// <value> The old value. </value>
        ///-------------------------------------------------------------------------------------------------

        public TValue OldValue { get; private set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the new value. </summary>
        ///
        /// <value> The new value. </value>
        ///-------------------------------------------------------------------------------------------------

        public TValue NewValue { get; private set; }
    }
}