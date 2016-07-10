using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleInjector;
using Snake.Services;

namespace Snake
{
    class Program
    {
        private static Container container = new Container();

        static void Main(string[] args)
        {
            
            Initialize().Start(100);
           
            

        }



        private static GameEngine Initialize()
        {
            container.Register<IControllerService,ControllerService>(Lifestyle.Singleton);
            container.Register<IGameObjectService, GameObjectService>(Lifestyle.Singleton);
            container.Register<ICollisionDetector,CollisionDetector>(Lifestyle.Singleton);
            var game = container.GetInstance<GameEngine>();
            game.GameObjects.Add(container.GetInstance<Apple>());
            game.GameObjects.Add(container.GetInstance<Snake>());
            container.GetInstance<ICollisionDetector>().DataSource = game.GameObjects;
            container.GetInstance<IGameObjectService>().DataSource = game.GameObjects;
            return game;
            //game.AddGameObject(container.GetInstance<Snake>());

        }
    }
}
