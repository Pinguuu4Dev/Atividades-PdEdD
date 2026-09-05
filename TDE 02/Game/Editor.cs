using Raylib_cs;
using System.Numerics;
using TDE_CS.Core;

namespace TDE_CS.Game
{
    internal class Editor : BaseObject
    {
        private Texture2D[] _textures;
        private int _selected = 0;
        private List<SpriteObject> _placedObjects = new List<SpriteObject>();
        private List<SpriteObject> _removedObjects = new List<SpriteObject>();
        public Editor()
        {
            _textures = new Texture2D[] {
                Raylib.LoadTexture("./assets/tree.png"),
                Raylib.LoadTexture("./assets/rock.png"),
            };
        }

        public override void Update(float delta)
        {
            if(Raylib.GetMouseWheelMove() < 0f || Raylib.IsKeyPressed(KeyboardKey.Right) || Raylib.IsKeyPressed(KeyboardKey.D))
            {
                _selected++;
                if (_selected >= _textures.Length)
                {
                    _selected = 0;
                }
            }
            if (Raylib.GetMouseWheelMove() > 0f || Raylib.IsKeyPressed(KeyboardKey.Left) || Raylib.IsKeyPressed(KeyboardKey.A))
            {
                _selected--;
                if (_selected < 0)
                {
                    _selected = _textures.Length - 1;
                }
            }

            if(Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 clickPosition = Scene.ScreenToWorld(Raylib.GetMousePosition());
                PlaceObject(_selected, clickPosition);
            }
            if(Raylib.IsKeyPressed(KeyboardKey.Z))
            {
                Undo();
            }
            if(Raylib.IsKeyPressed(KeyboardKey.Y))
            {
                Redo();
            }
        }

        public override void Draw()
        {
            Texture2D texture = _textures[_selected];
            Vector2 halfSize = new Vector2(texture.Width, texture.Height) / 2f;
            Vector2 mousePosition = Raylib.GetMousePosition();
            Raylib.DrawTexture(_textures[_selected], (int)(mousePosition.X - halfSize.X), (int)(mousePosition.Y - halfSize.Y), Color.Black);
        }

        private void PlaceObject(int objectIndex, Vector2 worldPosition)
        {
            var newObject = new SpriteObject(_textures[objectIndex]);
            newObject.position = worldPosition;
            Scene.Current?.AddObject(newObject);
            _placedObjects.Add(newObject);
        }

        // Remove último objeto adicionado
        private void Undo()
        {
            if (_placedObjects.Count == 0) return;
            var lastObject = _placedObjects.Last();

            Scene.Current?.RemoveObject(lastObject);
            _removedObjects.Add(lastObject);
            _placedObjects.Remove(lastObject);
        }

        // Readiciona último objeto deletado, na posição em que estava
        private void Redo()
        {
            if (_removedObjects.Count == 0) return;
            var lastRemovedObject = _removedObjects.Last();

            Scene.Current?.AddObject(lastRemovedObject);
            _placedObjects.Add(lastRemovedObject);
            _removedObjects.Remove(lastRemovedObject);
        }
    }
}
