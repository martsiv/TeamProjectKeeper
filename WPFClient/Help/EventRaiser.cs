using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Help
{
    public static class EventRaiser
    {
        //Цей метод призначений для підняття подій, які не мають параметрів. 
        public static void Raise(this EventHandler handler, object sender)
        {
            handler?.Invoke(sender, EventArgs.Empty);
        }
        //Цей метод дозволяє піднімати події з одним параметром типу T. Він приймає делегат EventHandler<EventArgs<T>>,
        //відправника та значення, яке потрібно передати як параметр події.
        //Метод створює новий екземпляр EventArgs<T> і передає його разом із відправником делегату події.
        public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, T value)
        {
            handler?.Invoke(sender, new EventArgs<T>(value));
        }
        //T успадковує EventArgs:
        //Цей метод призначений для підняття подій, які мають аргумент, що успадковує EventArgs.
        //Він приймає делегат EventHandler<T>, відправника та значення типу T, яке успадковує EventArgs.
        //Цей метод викликає делегат події, передаючи йому відправника та аргумент події value.
        public static void Raise<T>(this EventHandler<T> handler, object sender, T value) where T : EventArgs
        {
            handler?.Invoke(sender, value);
        }
        //Цей метод призначений для підняття подій, які мають аргумент типу EventArgs<T>.
        //Він приймає делегат EventHandler<EventArgs<T>>, відправника та аргумент події типу EventArgs<T>.
        //Цей метод викликає делегат події, передаючи йому відправника та аргумент події value.
        public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, EventArgs<T> value)
        {
            handler?.Invoke(sender, value);
        }
    }
}
