using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Snake.Services;

namespace Snake
{
    public class GameEngine
    {
        public List<IGameObject> GameObjects = new List<IGameObject>();
        private ICollisionDetector _collisionDetector;
      public GameEngine(ICollisionDetector collisionDetector)
      {
          _collisionDetector = collisionDetector;
      }
        
        public void Start(int speed)
        {
            var v = Stopwatch.StartNew();
            bool gameRunning = true;
            while (gameRunning)
            {
                var startTime = v.ElapsedMilliseconds;
                ReadInput();
                Move();
                Draw();
                var elapsed = v.ElapsedMilliseconds - startTime;
                if (elapsed < speed)
                    Thread.Sleep(TimeSpan.FromMilliseconds(speed - elapsed));
            }
        }

        private void ReadInput()
        {
          
        }

        private void Draw()
        {
            char[][] backgroundbuffer = new char[Console.WindowHeight][];

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                backgroundbuffer[i] = new char[Console.WindowWidth-1];
            }
            foreach (var gameObject in GameObjects.OfType<IDrawable>())
            {
                gameObject.Draw(backgroundbuffer);

            }
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < backgroundbuffer.Length-1; i++)
            {
                if (i == backgroundbuffer.Length - 2)
                    Console.Write(backgroundbuffer[i]);
                else
                    Console.WriteLine(backgroundbuffer[i]);
            }
            

        }

        private void Move()
        {
            foreach (var movable in GameObjects.OfType<IMovable>().ToArray())
            {
           
                if (!_collisionDetector.CheckCollision(movable))
       
                    movable.Move();
          
            
                
                

            }
        }

  
    }
}