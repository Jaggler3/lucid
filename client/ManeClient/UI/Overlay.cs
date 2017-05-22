using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mane.UI
{
    class Overlay : UIObject
    {
        public Texture2D Texture;
        public Vector2 Size;

        public Color RenderColor = Color.White;

        public Overlay() { }

        public Overlay(Texture2D Texture)
        {
            this.Texture = Texture;
            Size = new Vector2(Texture.Width, Texture.Height);
        }

        public Overlay(Texture2D Texture, Vector2 Size)
        {
            this.Texture = Texture;
            this.Size = Size;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            if(Texture != null)
            {
                spriteBatch.Draw(Texture, GetRect(Size), RenderColor);
            }
        }

        public override void Update()
        {

        }
    }
}
