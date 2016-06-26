using System;

namespace SnowFlake2._0
{
    public class Block : IColidable, IDrawable, ISceneObject, IMovable
    {
        public ConsoleColor Color { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        private CollisionDetector _collisionDetector;
        public bool isMoving { get; set; }
        public int OldX { get; set; }
        public int OldY { get; set; }
        public Block(int posX, int posY, CollisionDetector collisionDetector)
        {
            isMoving = true;
            PosY = OldY = posY;
            PosX = OldX = posX;
            _collisionDetector = collisionDetector;
        }
        public bool Collides(int x, int y)
        {
            if (y == PosY && x == PosX)
            {
                return true;
            }
            return false;
        }

        public void Draw()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = Color;
            Console.WriteLine("%");
        }


        public void MoveObject()
        {
            if (!isMoving)
            {
                return;
            }
            if (CanMove(PosX, PosY + 1))
            {
                OldY = PosY++;
                ClearOld();
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
    }
}