using System;

namespace SnowFlake2._0
{
    public class Flake : IMovable, ISceneObject
    {
        public bool isMoving { get; set; }
        public int OldX { get; set; }
        public int OldY { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Flake(int posX,int posY)
        {
            isMoving = true;
            PosY= OldY = posY;
            PosX = OldX= posX;

        }
        public void MoveObject()
        {
            if (isMoving && PosY < Console.WindowHeight)
            {
                OldX = PosX;
                OldY = PosY;
    
            }
        }
    }


}