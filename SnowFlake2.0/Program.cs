using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnowFlake2._0
{
    class Program
    {
        static List<ISceneObject> _sceneObjects = new List<ISceneObject>();
        private static List<IGenerator> _generators = new List<IGenerator>();
        private static List<IMovable> _movables = new List<IMovable>();
        private static List<IDrawable> _drawables = new List<IDrawable>();
        private static List<IColidable> _colidables = new List<IColidable>();
        private static int _speed = 100;
        private static CollisionDetector _collisionDetector;
        static void Main(string[] args)
        {
            Initialize();
            var running = true;
            var v = Stopwatch.StartNew();

            while (running)
            {
                var startTime = v.ElapsedMilliseconds;
                Generate();
                Move();
                Draw(_sceneObjects);
                var elapsed = v.ElapsedMilliseconds - startTime;
                if (elapsed < _speed)
                    Thread.Sleep(TimeSpan.FromMilliseconds(_speed - elapsed));
            }
        }

        private static void Move()
        {
            foreach (var movable in _movables)
            {
                movable.MoveObject();
            }
        }
        private static void Generate()
        {
            foreach (var generator in _generators)
                foreach (var generateObject in generator.GenerateObjects())
                {
                    _sceneObjects.Add(generateObject);
                    if (generateObject is IMovable)
                        _movables.Add(generateObject as IMovable);
                    if (generateObject is IDrawable)
                        _drawables.Add(generateObject as IDrawable);
                    if (generateObject is IColidable)
                        _colidables.Add(generateObject as IColidable);
                }
        }
        private static void Initialize()
        {
            _collisionDetector = new CollisionDetector(_colidables);
            _generators.Add(new ObjectGenerator(_collisionDetector));
        }

        private static void Draw(List<ISceneObject> sceneObject)
        {

            foreach (var drawable in _drawables)
                drawable.Draw();
        }
        private static string CheckCollision(Flake flake)
        {

            return "down";
        }
    }
}
