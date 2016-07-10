using System.Collections.Generic;
using System.Linq;
using Snake.Services;

namespace Snake
{
    public class CollisionDetector : ICollisionDetector
    {
        public List<ICollidable> Collidables = new List<ICollidable>();

        public List<IGameObject> DataSource { get; set; }

        public bool CheckCollision(IGameObject gameObject)
        {
            foreach (var collidable in DataSource.OfType<ICollidable>())
            {
                if (collidable.Collides(gameObject.PosX, gameObject.PosY))
                {
                    var collisionObject = gameObject as ICollision;
                    if (collisionObject != null)
                        collisionObject.Collision(collidable);
                    return true;
                }
            }
         
            return false;
        }
    }
}