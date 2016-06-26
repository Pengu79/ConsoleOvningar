using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlake2._0
{
    class Program
    {
       static List<ISceneObject> _sceneObjects = new List<ISceneObject>();
        static void Main(string[] args)
        {
            var running = true;
            
            
            while (running)
            {
                AddRandomFlakes();
                DrawScene(_sceneObjects);
            }
            

        }

        private static void AddRandomFlakes()
        {

            Random rnd = new Random();
            if (_sceneObjects.Count<100)
            {
                Flake flake = new Flake(rnd.Next(Console.WindowWidth), 0);
                _sceneObjects.Add(flake);
            }
            
        }

        private static void DrawScene(List<ISceneObject> sceneObject )
        {
            if (sceneObject.Count<Console.WindowWidth)
            {
                CreateGround();
            }

            foreach (var flake in sceneObject.OfType<Flake>())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(flake.OldX, flake.OldY);
                Console.Write(" ");
                Console.SetCursorPosition(flake.PosX, flake.PosY);
                Console.Write("O");
                flake.MoveObject(CheckCollision(flake));
                System.Threading.Thread.Sleep(1);
            }
        }

        private static string CheckCollision(Flake flake)
        {
            
            return "down";
        }

        private static void CreateGround()
        {
            //for (int i = 0; i < Console.WindowWidth; i++)
            //{
            //    Grass ground= new Grass() {Colidable = true,PosX = i,PosY = Console.WindowHeight-1};
            //    //_grass.Add(ground);
            //    }
            //foreach (var item in _grass)
            //{
            //    Console.SetCursorPosition(item.PosX, item.PosY);
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.Write("#");
            //}
        }
    }
}
