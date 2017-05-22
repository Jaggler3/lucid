using Lucid.Core;
using Lucid.SubSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lucid.GameCore
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
                return GameContent.GetTexture(path);
            }
        }

        public class PhysicsController
        {
            public float GravityVal = Physics.GravityVal;
        }

        public class RenderingAccess
        {
            public Vector2 CameraOffset
            {
                get
                {
                    return Rendering.CameraOffset;
                }
                set
                {
                    Rendering.CameraOffset = value;
                }
            }
        }
    }
}
