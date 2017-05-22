using Lucid.Core;
using Lucid.SubSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MoonSharp.Interpreter;
using System;

namespace Lucid.GameCore
{
    class GameObject : Entity
    {
        public PhysicsObject collider = new PhysicsObject();

        private Vector2 _position = Vector2.Zero;
        private Vector2 _size;

        private static Random _objr = new Random();
        private readonly int _objectID = _objr.Next(0, int.MaxValue);

        public int ObjectID
        {
            get
            {
                return _objectID;
            }
        }

        public Vector2 Position {
            get { return _position; }
            set { _position = value; collider.Position = value; }
        }

        public Vector2 Size {
            get { return _size; }
            set { _size = value; collider.Size = value; }
        }
        
        public Texture2D Texture;

        public GameScript script;

        public int Layer = 0;

        public SpriteEffects DrawEffects;

        public Color RenderColor;

        public GameObject()
        {
            collider = new PhysicsObject();
            DrawEffects = SpriteEffects.None;
            RenderColor = Color.White;
        }

        public GameObject(string Name)
        {
            this.Name = Name;
            collider = new PhysicsObject();
            DrawEffects = SpriteEffects.None;
            RenderColor = Color.White;
        }

        public GameObject(string Name, string Texture)
        {
            this.Name = Name;
            this.Texture = GameContent.GetTexture(Texture);
            Size = new Vector2(this.Texture.Width, this.Texture.Height);
            collider = new PhysicsObject();
            DrawEffects = SpriteEffects.None;
            RenderColor = Color.White;
        }

        public GameObject(string Name, string Texture, Vector2 Position, Vector2 Size)
        {
            this.Name = Name;
            this.Texture = GameContent.GetTexture(Texture);
            this.Position = Position;
            this.Size = Size;
            collider = new PhysicsObject();
            DrawEffects = SpriteEffects.None;
            RenderColor = Color.White;
        }

        public void NewScript(string Name, string Path)
        {
            script = new GameScript(this, Name, Path);
        }

        public void NewScript(string Source)
        {
            script = new GameScript(this, Source);
        }

        public void Start()
        {
            if (script != null)
            {
                script.Invoke("Start");
            }
        }

        public void SetToHorizontalFlipped()
        {
            DrawEffects = SpriteEffects.FlipHorizontally;
        }

        public void SetToVerticalFlipped()
        {
            DrawEffects = SpriteEffects.FlipVertically;
        }

        public void SetToHorizontalVerticalAligned()
        {
            DrawEffects = SpriteEffects.None;
        }

        public void Translate(float x, float y)
        {
            Vector2 res = new Vector2(Position.X + x, Position.Y + y);
            Position = Physics.Approve(collider, res).Contact ? Position : res;
        }

        public void ApplyForce(Vector2 force)
        {
            collider.ApplyForce(force);
        }

        public void ApplyForce(float x, float y)
        {
            ApplyForce(new Vector2(x, y));
        }

        public bool Grounded
        {
            get
            {
                return collider.Velocity == Vector2.Zero;
            }
        }

        public void setPosition(Vector2 position)
        {
            Position = position;
        }

        public bool MouseClicked
        {
            get
            {
                return GetRenderRect().Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed;
            }
        }

        public override void Update()
        {
            Position = collider.Position;
            if(script != null)
            {
                script.SetGlobal("deltaTime", Scene.gameTime.ElapsedGameTime.Milliseconds / 1000f);
                script.Invoke("Update");
            }
        }

        public void Destroy()
        {
            if(Scene.GetState().Entities.IndexOf(this) != -1)
            {
                Scene.GetState().Entities.Remove(this);
                Physics.RemoveObject(collider);
                script.Invoke("Destruct");
            }
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            if(Texture == null) { return; }
            //TODO: implement rotations, for rendering and for physics --\|/
            //TODO: implement layers to work with physics (or not?) -----------------------------\|||||/
            spriteBatch.Draw(Texture, GetRenderRect(), null, RenderColor, 0, Vector2.Zero, DrawEffects, Layer);
        }

        public Rectangle GetRenderRect()
        {
            return new Rectangle(
                (int)Math.Round((-_size.X / 2) + _position.X + Display.GetWidth() / 2 + Rendering.CameraOffset.X),
                (int)Math.Round((-_size.Y / 2) - _position.Y + Display.GetHeight() / 2 - Rendering.CameraOffset.Y),
                (int)Math.Round(_size.X),
                (int)Math.Round(_size.Y));
        }
    }
}
