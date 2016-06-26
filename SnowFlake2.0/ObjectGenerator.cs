using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlake2._0
{
    public class ObjectGenerator : IGenerator
    {
        Random rnd = new Random();
        private bool _initialized;
        private int _flakeInterval = 1;
        private int _current;
        private CollisionDetector _collisionDetector;
        public ObjectGenerator(CollisionDetector collisionDetector)
        {
            _collisionDetector = collisionDetector;
        }
        public IEnumerable<ISceneObject> GenerateObjects()
        {
            List<ISceneObject> result = new List<ISceneObject>();
            if (!_initialized)
            {
                _initialized = true;
                result.AddRange(CreateInitialObjects());
            }
            if (_current == _flakeInterval)
            {
                result.Add(CreateFlake());
                _current = 0;
            }
            else
                _current++;
            return result;
        }

        private ISceneObject CreateFlake()
        {
            
            Flake flake = new Flake(rnd.Next(Console.WindowWidth), 0,_collisionDetector);
            return flake;
        }
        

        private IEnumerable<ISceneObject> CreateInitialObjects()
        {
            yield return new Ground() { PosY = Console.WindowHeight - 1 };

            foreach (var sceneObject in GenerateHouse(rnd.Next(0,Console.WindowWidth-11)))
            {
                yield return sceneObject;
            }
        }

        private IEnumerable<ISceneObject> GenerateHouse(int x)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    yield return new Block(x+i, j+10, _collisionDetector) { Color = ConsoleColor.Red };
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = i; j <11-i; j++)
                {
                    yield return new Block(x + j, i, _collisionDetector) { Color = ConsoleColor.Black };
                }
            }
            

        }
    }
}
