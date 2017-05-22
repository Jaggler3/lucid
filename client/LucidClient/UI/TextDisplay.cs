using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Lucid.SubSystems;
using Microsoft.Xna.Framework;

namespace Lucid.UI
{
    class TextDisplay : UIObject
    {
        public string Text = "";

        public const string DEF_FONT = "MainFont";

        public SpriteFont Font;
        public int FontSize;
        public Color TextColor;

        public enum TextAlignment
        {
            Left,
            Center,
            Right,
            Top,
            Bottom
        }

        public TextAlignment AlignmentX;
        public TextAlignment AlignmentY;

        public TextDisplay(string Text)
        {
            this.Text = Text;
            Position = Vector2.Zero;

            Font = GameContent.GetFont(DEF_FONT);
            TextColor = Color.Black;
            FontSize = 1;
            AlignmentX = TextAlignment.Left;
            AlignmentY = TextAlignment.Top;
        }

        public TextDisplay(string Text, Vector2 Position, int FontSize)
        {
            this.Text = Text;
            this.Position = Position;

            Font = GameContent.GetFont(DEF_FONT);
            TextColor = Color.Black;
            this.FontSize = FontSize;
            AlignmentX = TextAlignment.Left;
            AlignmentY = TextAlignment.Top;
        }

        public TextDisplay Align(TextAlignment X, TextAlignment Y)
        {
            AlignmentX = X;
            AlignmentY = Y;

            return this;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            if(Text == null || Text == "") { return; }

            Vector2 fp = Position;
            Vector2 m = Font.MeasureString(Text) * FontSize;

            if (AlignmentX == TextAlignment.Center)
            {
                fp.X -= m.X / 2;
            } else if(AlignmentX == TextAlignment.Right)
            {
                fp.X -= m.X;
            }

            if (AlignmentY == TextAlignment.Center)
            {
                fp.Y -= m.Y / 2;
            }
            else if (AlignmentY == TextAlignment.Bottom)
            {
                fp.Y -= m.Y;
            }

            spriteBatch.DrawString(Font, Text, fp, TextColor, 0, Vector2.Zero, FontSize, SpriteEffects.None, 0);
        }

        public override void Update()
        {

        }
    }
}
