using System;

namespace SnowFlake2._0
{
    public class Flake : IMovable, ISceneObject, IColidable
    {
        public bool isMoving { get; set; }
        public int OldX { get; set; }
        public int OldY { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool Colidable { get; set; }

        public Flake(int posX, int posY)
        {
            isMoving = true;
            Colidable = false;
            PosY = OldY = posY;
            PosX = OldX = posX;

        }
        public void MoveObject(string direction)
        {
            if (PosY>=Console.WindowHeight-2)
            {
                isMoving = false;
                Colidable = true;
            }
            if (isMoving && PosY < Console.WindowHeight)
            {
                OldX = PosX;
                OldY = PosY;
                switch (direction)
                {
                    case "down":
                        PosY++;
                        return;
                }
            }
        }

      
    }


}