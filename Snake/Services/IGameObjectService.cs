using System.Collections.Generic;

namespace Snake.Services
{
    public interface IGameObjectService
    {
        List<IGameObject> DataSource { get; set; }
        void GrowSnake(IGameObject iGameObject);
        void RemoveGameObject(IGameObject gameObject);
    }
}