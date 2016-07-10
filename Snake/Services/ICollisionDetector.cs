using System.Collections.Generic;

namespace Snake.Services
{
    public interface ICollisionDetector
    {
        List<IGameObject> DataSource { get; set; }
        bool CheckCollision(IGameObject gameObject);
    }
}