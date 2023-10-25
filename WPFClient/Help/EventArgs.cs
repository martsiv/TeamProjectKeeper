using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Help
{
    //Клас EventArgs<T> є узагальненим класом, що означає, що ви можете вказати конкретний тип даних (T),
    //який ви хочете передати разом із подією. В даному випадку T - це тип даних, який буде передаватися як аргумент у вашій події.
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }
        public T Value { get; private set; }
    }
}
