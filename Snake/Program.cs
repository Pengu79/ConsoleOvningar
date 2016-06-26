using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        private static IPlayer _player;
        private static List<IGameObject> _gameObjects; 
        static void Main(string[] args)
        {
            int _speed = 100;
            Initialize();
            var v = Stopwatch.StartNew();
            bool gameRunning = true;
            while (gameRunning)
            {

                var startTime = v.ElapsedMilliseconds;
                _player.ReadInput();
                Move();
                Draw();
                var elapsed = v.ElapsedMilliseconds - startTime;
                if (elapsed < _speed)
                    Thread.Sleep(TimeSpan.FromMilliseconds(_speed - elapsed));
            }
        }

        private static void Draw()
        {
            
        }

        private static void Move()
        {
            foreach (var movable in _gameObjects.OfType<IMovable>())
            {
            movable.Move();
            }
        }

        private static void Initialize()
        {
            _player=new Snake();
            _gameObjects.Add(_player);
        }
    }
}
