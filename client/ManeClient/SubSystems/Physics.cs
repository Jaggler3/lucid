using Mane.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace Mane.SubSystems
{
    class Physics
    {
        public const float GravityVal = -9.81f * 100f;
        public static List<PhysicsObject> world = new List<PhysicsObject>();

        public class CollisionData
        {
            public PhysicsObject Collider;

            public bool Contact = false;

            public Vector2 resolve = Vector2.Zero;

            public CollisionData(PhysicsObject Collider, bool Contact)
            {
                this.Collider = Collider;
                this.Contact = Contact;
            }
        }

        internal static void Clear()
        {
            world.Clear();
        }

        public static void AddObject(PhysicsObject po)
        {
            world.Add(null);
            world[world.Count - 1] = po;
        }

        public static void RemoveObject(PhysicsObject po)
        {
            world.Remove(po);
        }

        public static void Step(GameTime gameTime)
        {
            for (int i = 0; i < world.Count; i++)
            {
                PhysicsObject po = world[i];

                if(po.Static)
                {
                    // dont move
                }
                else
                {
                    po.Position = Move(po, gameTime.ElapsedGameTime.Milliseconds / 1000f);
                }
            }
        }

        public static Vector2 Move(PhysicsObject po, float delta)
        {
            Vector2 res = po.Position + po.Velocity * po.Mass * delta;
            CollisionData approve = Approve(po, res);

            if(approve.Contact) // not approved
            {
                po.Velocity = Vector2.Zero;
                return po.Position + approve.resolve;
            }

            po.Velocity.Y += delta * GravityVal;

            return res; // approved
        }

        public static CollisionData Approve(PhysicsObject po, Vector2 res)
        {
            for (int i = 0; i < world.Count; i++)
            {
                if (world[i] != po && world[i].HasCollision(po.Size, res))
                {
                    CollisionData cd = new CollisionData(world[i], true);

                    cd.resolve = Resolve(po, world[i]);

                    return cd;
                }
            }
            return new CollisionData(null, false);
        }

        public static Vector2 Resolve(PhysicsObject po, PhysicsObject c)
        {
            // calculate how much the player should move so that it is on the collided object's edge
            return Vector2.Zero;
        }
    }
}
