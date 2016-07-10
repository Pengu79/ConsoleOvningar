using System.Security.AccessControl;

namespace Snake
{
    public interface IMovable:IGameObject
    {
        int OldX { get; set; }
        int OldY { get; set; }
        void Move();
       
    }
}