using Raylib_cs;
using System.Numerics;

namespace TDE_CS.Core
{
    internal class Scene
    {
        private List<BaseObject> _objects = new();
        private Queue<BaseObject> _addQueue = new();
        private Queue<BaseObject> _rmQueue = new();
        
        public static Scene? Current { get; private set; }

        public void AddObject(BaseObject baseObject)
        {
            _addQueue.Enqueue(baseObject);
        }

        public void RemoveObject(BaseObject baseObject)
        {
            _rmQueue.Enqueue(baseObject);
        }

        protected virtual void PreUpdate(float delta) { }

        private void Update(float delta)
        {
            Current = this;
            while (_addQueue.Count > 0)
            {
                _objects.Add(_addQueue.Dequeue());
            }
            while (_rmQueue.Count > 0)
            {
                _objects.Remove(_rmQueue.Dequeue());
            }
            foreach (BaseObject baseObject in _objects)
            {
                if(baseObject.active && !_rmQueue.Contains(baseObject))
                {
                    baseObject.Update(delta);
                }
            }
        }

        protected virtual void PostUpdate(float delta) { }

        protected virtual void PreDraw() { }

        private void Draw()
        {
            foreach (BaseObject baseObject in _objects)
            {
                if (baseObject.active)
                {
                    baseObject.Draw();
                }
            }
        }

        protected virtual void PostDraw() { }

        public void Run()
        {
            Current = this;
            while (!Raylib.WindowShouldClose())
            {
                PreUpdate(Raylib.GetFrameTime());
                Update(Raylib.GetFrameTime());
                PostUpdate(Raylib.GetFrameTime());

                Raylib.BeginDrawing();
                PreDraw();
                Draw();
                PostDraw();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        public BaseObject? GetObjectAtPosition(Vector2 worldPosition, BaseObject[] toIgnore)
        {
            foreach (BaseObject baseObject in _objects)
            {
                if(!baseObject.active || toIgnore.Contains(baseObject))
                {
                    continue;
                }
                Vector2 objectPosition = baseObject.position;
                Vector2 halfSize = baseObject.Size / 2f;
                if(
                    worldPosition.X > objectPosition.X - halfSize.X &&
                    worldPosition.X < objectPosition.X + halfSize.X &&
                    worldPosition.Y > objectPosition.Y - halfSize.Y &&
                    worldPosition.Y < objectPosition.Y + halfSize.Y
                )
                {
                    return baseObject;
                }
            }
            return null;
        }

        public bool HasObject(BaseObject baseObject)
        {
            return (_addQueue.Contains(baseObject) || _objects.Contains(baseObject)) && !_rmQueue.Contains(baseObject);
        }

        public static Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return new Vector2(screenPosition.X - Raylib.GetScreenWidth() / 2, screenPosition.Y - Raylib.GetScreenHeight() / 2);
        }
    }
}
