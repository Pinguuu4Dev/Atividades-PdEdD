using Raylib_cs;
using System.Numerics;
using TDE_CS.Core;
using TDE_CS.Game.Tasks;

namespace TDE_CS.Game
{
    internal class Player : SpriteObject
    {
        private TaskExecutor _executor;

        public Player(Texture2D texture) : base(texture)
        {
            _executor = new TaskExecutor(this);
        }
        
        public override void Update(float delta)
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 clickPosition = Scene.ScreenToWorld(Raylib.GetMousePosition());
                BaseTask task = GetTask(clickPosition);
                _executor.AddToTaskList(task);
            }

            _executor.Update(delta);
        }
        public TaskExecutor GetExecutor => _executor;
        private BaseTask GetTask(Vector2 worldPosition)
        {
            BaseObject? target = Scene.Current?.GetObjectAtPosition(worldPosition, new[] { this });
            if (target != null)
            {
                return new DestroyTask(target);
            }
            return new WalkTask(worldPosition);
        }
    }
}
