namespace Snake
{
    public class SnakePart:IDrawable,IGameObject,IMovable
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        private IMovable gameObject;
        public int OldX { get; set; }
        public int OldY { get; set; }

        public void Move()
        {
            PosX = gameObject.OldX;
            PosY = gameObject.OldY;
        }

        public SnakePart(IMovable iGameObject)
        {
            gameObject = iGameObject;
            PosY = iGameObject.PosY;
            PosX = iGameObject.PosX;
        }
        public void Draw(char[][] doublebuffer)
        {
            doublebuffer[PosY][PosX] = '%';
        }

        
    }
}