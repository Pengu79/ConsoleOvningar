using System;

namespace Snake
{
    public interface IControllable:IGameObject
    {
        void ParseInput(ConsoleKeyInfo key);
    }
}