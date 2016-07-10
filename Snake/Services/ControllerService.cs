using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Services
{
    public class ControllerService : IControllerService
    {
        public event EventHandler<EventArgs<ConsoleKey>> KeyPressed;

        public ControllerService()
        {
            Task.Run(() =>
            {
                while (true)
                    ReadInput();
                // ReSharper disable once FunctionNeverReturns
            });
        }

        private void ReadInput()
        {
            ConsoleKeyInfo userKey;
            if (Console.KeyAvailable)
            {
                userKey = Console.ReadKey(true);
               KeyPressed?.Invoke(this,new EventArgs<ConsoleKey> {Data = userKey.Key});
            }
        }
    }
}
