using System.Collections.Generic;
using System.Linq;

namespace SnowFlake2._0
{
    public class CollisionDetector
    {
        private List<IColidable> _colidables; 
        public CollisionDetector(List<IColidable> colidables)
        {
            _colidables = colidables;
        }

        public bool CheckCollision(int x, int y)
        {
            foreach (var colidable in _colidables)
            {
                if (colidable.Collides(x,y))
                {
                    return true;
                }
            }

            return false;
        }
    }
}