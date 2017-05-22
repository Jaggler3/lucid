using Microsoft.Xna.Framework.Graphics;
using System;
namespace Mane.SubSystems
{
    class GameContent
    {
        //The list of textures to be loaded on startup
        public static string[] TextureNames = new string[] {
            "splash/dev",
            "splash/monogame",
            "units/unit",
            "units/corner_left",
            "player/player_idle",
            "wall_left",
            "wall_right",
            "black",
            "white",
            "ui/button",
            "ui/button_hover"
        };

        public static string[] FontNames = new string[]
        {
            "MainFont",
        };
        
        public static Texture2D[] LoadedTextures = new Texture2D[TextureNames.Length];
        public static SpriteFont[] LoadedFonts = new SpriteFont[FontNames.Length];

        //Returns a font loaded on startup based on name/path
        public static SpriteFont GetFont(string name)
        {
            for (int i = 0; i < LoadedFonts.Length; i++)
            {
                if (FontNames[i] == name)
                {
                    return LoadedFonts[i];
                }
            }

            return null;
        }

        //Returns a texture loaded on startup based on name/path
        public static Texture2D GetTexture(string name)
        {
            for(int i = 0; i < LoadedTextures.Length; i++)
            {
                if(TextureNames[i] == name)
                {
                    return LoadedTextures[i];
                }
            }

            return null;
        }
    }
}
