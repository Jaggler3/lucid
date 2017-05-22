using Lucid.GameCore;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Lucid.UI
{
    abstract class UIObject : Entity
    {
        public Vector2 Position;

        public Rectangle GetRect(Vector2 Size)
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }
    }
}
