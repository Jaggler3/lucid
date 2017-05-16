using Mane.Core;
using Mane.SubSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MoonSharp.Interpreter;
using System;

namespace Mane.GameCore
{
    class GameObject : Entity
    {
        public PhysicsObject collider = new PhysicsObject();

        private Vector2 _position;
        private Vector2 _size;

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

        public GameObject()
        {
            collider = new PhysicsObject();
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

        public void translate(float x, float y)
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
                return new Rectangle(
                (int)Math.Round((-_size.X / 2) + _position.X + Display.GetWidth() / 2),
                (int)Math.Round((-_size.Y / 2) + -_position.Y + Display.GetHeight() / 2),
                (int)Math.Round(_size.X),
                (int)Math.Round(_size.Y)).Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed;
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
            Rectangle rect = new Rectangle(
                (int)Math.Round((-_size.X / 2) + _position.X + Display.GetWidth() / 2), 
                (int)Math.Round((-_size.Y / 2) + -_position.Y + Display.GetHeight() / 2), 
                (int)Math.Round(_size.X), 
                (int)Math.Round(_size.Y));
            spriteBatch.Draw(Texture, rect, Color.White);
        }
    }
}
