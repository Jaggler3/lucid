using Lucid.SubSystems;
using Microsoft.Xna.Framework;
using System;

namespace Lucid.Core
{
    class PhysicsObject
    {
        public Vector2 Position;
        public Vector2 Size;

        public Vector2 Velocity;
        public Vector2 Acceleration;

        public float Mass;

        public bool Static = true;

        public PhysicsObject()
        {
            Position = Vector2.Zero;
            Size = Vector2.Zero;
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            Mass = 1;

            Physics.AddObject(this);
        }

        public PhysicsObject(Vector2 Position, Vector2 Size)
        {
            this.Position = Position;
            this.Size = Size;

            Physics.AddObject(this);
        }

        public void ApplyForce(Vector2 force)
        {
            Velocity += force;
        }

        public void ApplyForce(float x, float y)
        {
            ApplyForce(new Vector2(x, y));
        }

        public void setPosition(Vector2 Position)
        {
            this.Position = Position;
        }

        public void setSize(Vector2 Size)
        {
            this.Size = Size;
        }

        //Returns true if the given position and size of an object overlaps this PhysicsObject
        public bool HasCollision(Vector2 poSize, Vector2 poPosition)
        {
            if (Size.X == 0 || Size.Y == 0 || poSize.X == 0 || poSize.Y == 0)
            {
                return false;
            }
            
            return !Rectangle.Intersect(GetRect(), GetRect(poPosition, poSize)).IsEmpty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="po">The PhysicsObject that we are testing an overlap on</param>
        /// <returns>True if <paramref name="po"/> overlaps this PhysicsObject</returns>
        public bool HasCollision(PhysicsObject po)
        {
            if(Size.X == 0 || Size.Y == 0 || po.Size.X == 0 || po.Size.Y == 0)
            {
                return false;
            }
            
            return !Rectangle.Intersect(GetRect(), po.GetRect()).IsEmpty;
        }

        public Rectangle GetRect()
        {
            return GetRect(Position, Size);
        }

        public static Rectangle GetRect(Vector2 Position, Vector2 Size)
        {
            return new Rectangle((int)(Position.X - Size.X / 2), (int)(Position.Y - Size.Y / 2), (int)Size.X, (int)Size.Y);
        }

        public float Distance(PhysicsObject po)
        {
            return (float)Math.Sqrt(Math.Pow(po.Position.X - Position.X, 2) + Math.Pow(po.Position.Y - Position.Y, 2));
        }
    }
}
