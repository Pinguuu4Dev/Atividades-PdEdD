using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TDE_CS.Core;

namespace TDE_CS.Game.Tasks
{
    internal class WalkTask : BaseTask
    {
        private Vector2 _destination;
        public WalkTask(Vector2 destination)
        {
            _destination = destination;
        }
        public override bool TryExecute(BaseObject host, float delta)
        {

            float oldDist = Vector2.DistanceSquared(host.position, _destination);
            host.position += Vector2.Normalize(_destination - host.position) * 150f * delta;
            float newDist = Vector2.DistanceSquared(host.position, _destination);
            if (newDist > oldDist)
            {
                return false;
            }
            return true;
        }
    }
}
