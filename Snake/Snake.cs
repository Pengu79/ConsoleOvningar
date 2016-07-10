using System;
using System.Collections.Generic;
using Snake.Services;

namespace Snake
{
    public class Snake : IMovable, IDrawable, ICollidable, ICollision
    {
        private static readonly Random R = new Random();
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int OldX { get; set; }
        public int OldY { get; set; }
        public Directions Direction { get; set; }
        private IGameObject _lastExtension;
        private IGameObjectService _gameObjectService;

        public Snake(IControllerService controllerService, IGameObjectService gameObjectService)
        {
            controllerService.KeyPressed += ControllerService_KeyPressed;
            _lastExtension = this;
            PosX = OldX = R.Next(10, Console.WindowWidth - 10);
            PosY = OldY = R.Next(10, Console.WindowHeight - 10);

            _gameObjectService = gameObjectService;
        }

        private void ControllerService_KeyPressed(object sender, EventArgs<ConsoleKey> e)
        {
            ParseInput(e.Data);
        }

        public void Draw(char[][] doublebuffer)
        {
            doublebuffer[PosY][PosX] = '#';
        }



        public void Move()
        {
            OldX = PosX;
            OldY = PosY;
            switch (Direction)
            {
                case Directions.Left:
                    PosX--;
                    break;
                case Directions.Right:
                    PosX++;
                    break;
                case Directions.Up:
                    PosY--;
                    break;
                case Directions.Down:
                    PosY++;
                    break;

            }
        }

        public void ParseInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    Direction = Directions.Left;
                    break;
                case ConsoleKey.RightArrow:
                    Direction = Directions.Right;
                    break;
                case ConsoleKey.UpArrow:
                    Direction = Directions.Up;
                    break;
                case ConsoleKey.DownArrow:
                    Direction = Directions.Down;
                    break;
            }
        }


        public bool Collides(int x, int y)
        {
            return false;
            //return PosX==x&&PosY==y;
        }

        public void Collision(IGameObject gameObject)
        {
            var apple = gameObject as Apple;
            if (apple == null)
                return;
            _gameObjectService.GrowSnake(_lastExtension);
            _gameObjectService.RemoveGameObject(gameObject);
        }
    }
}