using Mane.Core;
using Mane.SubSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mane.GameCore
{
    class ScriptBindings
    {
        public class InputController
        {
            public bool IsKeyDown(char c)
            {
                return Keyboard.GetState().IsKeyDown((Keys)char.ToUpper(c));
            }
        }

        public class Loader
        {
            public static Texture2D GetTexture(string path)
            {
                Console.WriteLine(path);
                Console.WriteLine(GameContent.GetTexture(path).Height);
                return GameContent.GetTexture(path);
            }
        }

        public class PhysicsController
        {
            public float GravityVal = Physics.GravityVal;

            public Vector2 Gravity(PhysicsObject po, float force)
            {
                return Physics.Gravity(po, force);
            }
        }
    }
}
