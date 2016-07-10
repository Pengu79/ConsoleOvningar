using System;
using System.Security.Cryptography.X509Certificates;

namespace Snake.Services
{
    public interface IControllerService
    {
        event EventHandler<EventArgs<ConsoleKey>> KeyPressed;
    }

    public class EventArgs<T> : EventArgs
    {
        public T Data { get; set; }
    }
}