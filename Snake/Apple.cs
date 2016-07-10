using System;

namespace Snake
{
    public class Apple:IGameObject,IDrawable,ICollidable
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        Random Random= new Random();
        public Apple()
        {
            PosY = Random.Next(1, Console.WindowHeight);
            PosX = Random.Next(1, Console.WindowWidth);
        }
        public void Draw(char[][] doublebuffer)
        {
            doublebuffer[PosY][PosX] = '@';
        }

        public bool Collides(int x, int y)
        {
            return PosY == y && PosX == x;
            
        }

    }
}