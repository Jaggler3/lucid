using System;
using Mane.GameCore;
using Mane.SubSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mane.Control
{
    class Player
    {
        public static GameObject gameObject = new GameObject();

        public const int unitScale = 80;

        public static Vector2 playerSize = new Vector2(32, 70);

        public static GameObject Initialize()
        {
            gameObject.Name = "Player";
            gameObject.Position = new Vector2(0, 200);
            gameObject.Texture = GameContent.GetTexture("player/player_idle");
            gameObject.Size = playerSize;

            gameObject.collider.Mass = 1;

            gameObject.NewScript("Test", "Lua/player.lua");

            return gameObject;
        }

        public static void Update(GameTime gameTime)
        {
            // anything that can't be done in the player.lua script (or networking ?)
        }
    }
}
