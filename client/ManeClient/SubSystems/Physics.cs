using Mane.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace Mane.SubSystems
{
    class Physics
    {
        public const float GravityVal = 1000;
        public static List<PhysicsObject> world = new List<PhysicsObject>();

        public class CollisionData
        {
            public PhysicsObject Collider;

            public bool Contact = false;

            public CollisionData(PhysicsObject Collider, bool Contact)
            {
                this.Collider = Collider;
                this.Contact = Contact;
            }
        }

        public static void AddObject(PhysicsObject po)
        {
            world.Add(null);
            world[world.Count - 1] = po;
        }

        public static Vector2 Gravity(PhysicsObject po, float force)
        {
            Vector2 res = new Vector2(po.Position.X, po.Position.Y - force);
            CollisionData approve = Approve(po, res);
            if(approve.Contact) // approved
            {
                return new Vector2(po.Position.X, approve.Collider.Position.Y + approve.Collider.Size.Y / 2 + po.Size.Y / 2);
            }
            return res;
        }

        public static CollisionData Approve(PhysicsObject po, Vector2 res)
        {
            for (int i = 0; i < world.Count; i++)
            {
                if (world[i] != po && world[i].HasCollision(po.Size, res))
                {
                    return new CollisionData(world[i], true);
                }
            }
            return new CollisionData(null, false);
        }
    }
}
