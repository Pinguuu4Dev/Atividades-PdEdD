using TDE_CS.Core;

namespace TDE_CS.Game.Tasks
{
    internal abstract class BaseTask
    {
        public abstract bool TryExecute(BaseObject host, float delta);
    }
}
