using System.Numerics;
using TDE_CS.Core;

namespace TDE_CS.Game.Tasks
{
    internal class DestroyTask : BaseTask
    {
        private BaseObject _target;
        private bool _destroyed = false;
        private float timer = 0.5f;

        public DestroyTask(BaseObject target)
        {
            _target = target;
        }

        public override bool TryExecute(BaseObject host, float delta)
        {
            if(Scene.Current == null || !Scene.Current.HasObject(_target))
            {
                return false;
            }

            float distance = Vector2.Distance(host.position, _target.position);
            if(distance > 25f)
            {
                host.position += Vector2.Normalize(_target.position - host.position) * 150f * delta;
            }
            else
            {
                timer -= delta;
                if(timer < 0f)
                {
                    Scene.Current?.RemoveObject(_target);
                    return false;
                }
            }
            return true;
        }
    }
}
