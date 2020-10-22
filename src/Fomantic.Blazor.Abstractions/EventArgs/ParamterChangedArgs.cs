using System;

namespace Fomantic.Blazor.UI
{
    public class ParamterChangedArgs<TValue> : EventArgs
    {
        public ParamterChangedArgs(TValue oldValue, TValue newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
        public TValue OldValue { get; private set; }

        public TValue NewValue { get; private set; }
    }
}