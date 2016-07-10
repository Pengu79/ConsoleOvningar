using System.Collections.Generic;

namespace Snake.Services
{
    public class GameObjectService: IGameObjectService
    {
        public List<IGameObject> DataSource { get; set; }
        public void GrowSnake(IGameObject gameObject)
        {
           DataSource.Add(new SnakePart(gameObject as IMovable));
        }

        public void RemoveGameObject(IGameObject gameObject)
        {
            DataSource.Remove(gameObject);
        }
    }
}