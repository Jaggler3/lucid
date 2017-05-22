using Microsoft.Xna.Framework.Input;
using System;

namespace Lucid.SubSystems
{
    public class UserInput
    {
        public static bool IsKeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}
