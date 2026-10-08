using Raylib_cs;
using System.Numerics;

namespace TDE_CS.Core
{
    internal class SpriteObject : BaseObject
    {
        protected Texture2D texture;
        public override Vector2 Size => new Vector2(texture.Width, texture.Height);
        public SpriteObject(Texture2D texture)
        {
            this.texture = texture;
        }

        public override void Draw()
        {
            Vector2 texOffset = new Vector2(texture.Width, texture.Height) * -0.5f;
            Vector2 winOffset = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
            Raylib.DrawTextureV(texture, position + texOffset + winOffset, Color.White);
        }
    }
}
