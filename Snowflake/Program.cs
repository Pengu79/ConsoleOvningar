using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflake
{
    class Program
    {
       static List<Flake> flakes = new List<Flake>();
        static void Main(string[] args)
        {
           
            flakes.Add(new Flake());
            while (true)
            {
                if (flakes.Count < 100)
                {
                    flakes.Add(new Flake());
                }
               
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("#############################################################################");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;

                foreach (var flake in flakes)
                {
                  Console.SetCursorPosition(flake.PosX, flake.PosY-flake.Depth);
                    Console.Write("O");
                    flake.MoveFlake();
                    CheckSnowDepth();
                }
                System.Threading.Thread.Sleep(100);

            }
        }

        private static void CheckSnowDepth()
        {

            for (int i = 0; i < flakes.Count; i++)
            {
                for (int j = 0; j < flakes.Count; j++)
                {
                    if (flakes[i].PosX==flakes[j].PosX && flakes[j].PosY==21 && flakes[i].Depth==flakes[j].Depth && flakes[i]!=flakes[j] && flakes[i].PosY>=5 )
                    {
                        flakes[i].Depth++;
                    }
                }
            }
            
        }
    }
}
