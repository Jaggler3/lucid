using Mane.SubSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mane.UI
{
    public delegate void ClickCallback();
    class Button : UIObject
    {
        // just keep it simple for now

        public const string DEF_NORMAL_TEXTURE = "ui/button";
        public const string DEF_HOVER_TEXTURE = "ui/button_hover";

        public Vector2 Size;
        public Texture2D Texture;
        public Texture2D HoverTexture;

        private bool _hover = false;

        public bool Disabled = false;

        public bool Hover
        {
            get
            {
                return _hover;
            }
        }

        public ClickCallback Clicked;

        public Color RenderColor = Color.White;

        private bool MouseClicked = false;

        private TextDisplay _textDisplay;
        public Vector2 TextOffset = Vector2.Zero;

        public string Text { get { return _textDisplay.Text; } set { _textDisplay.Text = value; } }
        public int FontSize { get { return _textDisplay.FontSize; } set { _textDisplay.FontSize = value; } }
        public SpriteFont Font { get { return _textDisplay.Font; } set { _textDisplay.Font = value; } }

        public Button()
        {
            Texture = GameContent.GetTexture(DEF_NORMAL_TEXTURE);
            HoverTexture = GameContent.GetTexture(DEF_HOVER_TEXTURE);
            _textDisplay = new TextDisplay("");
        }

        public Button(Texture2D Texture, Texture2D HoverTexture)
        {
            this.Texture = Texture;
            this.HoverTexture = HoverTexture;
            RenderColor = Color.White;
            _textDisplay = new TextDisplay("");
        }

        public Button(Vector2 Position, Texture2D Texture, Texture2D HoverTexture)
        {
            this.Position = Position;
            this.Texture = Texture;
            this.HoverTexture = HoverTexture;
            RenderColor = Color.White;
            _textDisplay = new TextDisplay("");
        }

        public Button(Vector2 Position, Vector2 Size, Texture2D Texture, Texture2D HoverTexture)
        {
            this.Position = Position;
            this.Size = Size;
            this.Texture = Texture;
            this.HoverTexture = HoverTexture;
            RenderColor = Color.White;
            _textDisplay = new TextDisplay("");
        }

        public Button(Vector2 Position, Vector2 Size)
        {
            this.Position = Position;
            this.Size = Size;

            Texture = GameContent.GetTexture(DEF_NORMAL_TEXTURE);
            HoverTexture = GameContent.GetTexture(DEF_HOVER_TEXTURE);
            _textDisplay = new TextDisplay("");
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            if (Texture != null && HoverTexture != null)
            {
                spriteBatch.Draw(_hover ? HoverTexture : Texture, GetRect(Size), RenderColor);
                
                if(Text != null && Text != "")
                {
                    _textDisplay.Position = Position + TextOffset;
                    _textDisplay.Render(spriteBatch);
                }
            }
        }

        public TextDisplay GetTextDisplay()
        {
            return _textDisplay;
        }

        public override void Update()
        {
            _hover = Disabled ? false : GetRect(Size).Contains(Mouse.GetState().Position);

            if(!MouseClicked)
            {
                if (_hover && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    MouseClicked = true;
                    if(Clicked != null)
                    {
                        Clicked.Invoke();
                    }
                }
            }
            else if(!_hover)
            {
                MouseClicked = false;
            }
        }
    }
}
