using System;
using System.Security.AccessControl;

namespace Snowflake
{
    public class Flake
    {
        Random rnd = new Random();
        public int PosY { get; set; }
        public int PosX { get; set; }
        public int Depth { get; set; }
        
        public Flake()
        {
            PosY = 0;
            PosX = rnd.Next(0, 80);
            Depth = 0;
        }
        public void MoveFlake()
        {
            if (this.PosY < 21)
            {
                this.PosY++;
            }
            else
                this.PosY = 21;
        }

        public void IncreaseDepth()
        {
            this.Depth++;
        }

    }
}