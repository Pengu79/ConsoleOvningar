namespace Snake
{
    public interface ICollidable:IGameObject
    {
        bool Collides(int x, int y);
   
    }
}