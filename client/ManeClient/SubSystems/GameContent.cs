using Microsoft.Xna.Framework.Graphics;
using System;
namespace Mane.SubSystems
{
    class GameContent
    {
        public static string[] TextureNames = new string[] {
            "unit",
            "wall_left",
            "wall_right",
            "player/player_idle",
        };
        
        public static Texture2D[] LoadedTextures = new Texture2D[TextureNames.Length];

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
