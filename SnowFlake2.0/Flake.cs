using System;
using System.Runtime.InteropServices;

namespace SnowFlake2._0
{
    public class Flake : IMovable, ISceneObject, IColidable, IDrawable
    {
        public bool isMoving { get; set; }
        public int OldX { get; set; }
        public int OldY { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        

        private CollisionDetector _collisionDetector;

        public Flake(int posX, int posY, CollisionDetector collisionDetector)
        {
            isMoving = true;
            PosY = OldY = posY;
            PosX = OldX = posX;
            _collisionDetector = collisionDetector;
        }

        public void MoveObject()
        {
            if (!isMoving)
            {
                return;
            }
            if (CanMove(PosX, PosY + 1))
            {
                OldX = PosX;
                OldY = PosY++;
                ClearOld();
            }
            else if (CanMove(PosX - 1, PosY + 1))
            {
                OldY = PosY++;
                OldX = PosX--;
                ClearOld();
            }
            else if (CanMove(PosX + 1, PosY + 1))
            {
                OldY = PosY++;
                OldX = PosX++;
                ClearOld();
            }
            else
            {
                isMoving = false;
            }
        }

        private bool CanMove(int x, int y)
        {

            return !_collisionDetector.CheckCollision(x, y) && x >= 0 && x < 80;
        }

        private void ClearOld()
        {
            Console.SetCursorPosition(OldX, OldY);
            Console.Write(" ");
        }


        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(PosX, PosY);
            Console.Write("O");
        }

        public bool Collides(int x, int y)
        {
            return !isMoving && x == PosX && y == PosY;
        }
    }


}