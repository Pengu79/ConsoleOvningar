using System;

namespace SnowFlake2._0
{
    public class Ground : IDrawable, IColidable, ISceneObject
    {
        public int PosY { get; set; }
        public bool Drawn { get; set; }


        public Ground()
        {

        }


        public void Draw()
        {
            if (Drawn)
                return;
            Drawn = true;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(i, PosY);
                Console.WriteLine("#");
            }
        }

        public bool Collides(int x, int y)
        {
            if (y == PosY)
            {
                return true;
            }
            return false;
        }
    }
}