using System.Numerics;

namespace TDE_CS.Core
{
    internal class BaseObject
    {
        public bool active = true;
        public Vector2 position = Vector2.Zero;
        public virtual Vector2 Size => Vector2.Zero;

        public virtual void Update(float delta) { }
        public virtual void Draw() { }
    }
}
