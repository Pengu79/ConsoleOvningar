namespace Snake
{
    public class Wall:IDrawable,ICollidable
    {
        public Wall()
        {
            
        }
        public void Draw(char[][] doublebuffer)
        {
            throw new System.NotImplementedException();
        }

        public bool Collides(int x, int y)
        {
            return false;
        }

        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}