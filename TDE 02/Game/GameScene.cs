using Raylib_cs;
using TDE_CS.Core;
using TDE_CS.Game.Tasks;

namespace TDE_CS.Game
{
    internal class GameScene : Scene
    {
        private bool _edit = false;
        Player _player;
        Editor _editor;

        public GameScene()
        {
            Texture2D playerTexture = Raylib.LoadTexture("./assets/player.png");

            _player = new Player(playerTexture);
            AddObject(_player);
            _editor = new Editor();
            AddObject(_editor);
            SwitchMode();
        }

        private void SwitchMode()
        {
            _edit = !_edit;
            _player.active = !_edit;
            _editor.active = _edit;
        }

        protected override void PreUpdate(float delta)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                SwitchMode();
            }
        }

        protected override void PreDraw()
        {
            Raylib.ClearBackground(Color.DarkGreen);
        }

        protected override void PostDraw()
        {
            Raylib.DrawText($"{(_edit ? "Modo Editor" : "Modo Jogo")}: Pressione [espaço] para trocar", 10, 10, 24, Color.Black);
            if (_edit)
            {
                Raylib.DrawText("Use [A] e [D] para trocar o objeto, clique para posicionar.", 10, 40, 24, Color.Black);
                Raylib.DrawText("Use [Z] e [Y] para deletar um objeto ou reconstruir um objeto deletado.", 10, 70, 18, Color.Black);
            }
            else
            {
                Raylib.DrawText("Clique no chão ou em objetos para comandar o personagem.", 10, 40, 24, Color.Black);
                Raylib.DrawText("Lista de ações programadas: ", 10, 65, 16, Color.Black);
                Raylib.DrawText(string.Join(" | ", _player.GetExecutor.GetTaskNames), 10, 85, 16, Color.Black);
            }
        }
    }
}
