using Microsoft.Xna.Framework;
using System;

namespace Mane.SubSystems
{
    class Display
    {
        public const int INIT_WIDTH = 1280;
        public const int INIT_HEIGHT = 700;
        public const string TITLE = "Mane v0.1.0";

        public static Game mg_obj;
        public static GraphicsDeviceManager graphics;

        public static void Setup(Game _mg, GraphicsDeviceManager _graphics)
        {
            mg_obj = _mg;
            graphics = _graphics;
            SetTitle(TITLE);
            SetSize(INIT_WIDTH, INIT_HEIGHT);
            DisableVSync();
        }

        public static void SetSize(int width, int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
        }

        public static void SetTitle(string title)
        {
            mg_obj.Window.Title = title;
        }

        public static int GetWidth()
        {
            return graphics.GraphicsDevice.Viewport.Width;
        }

        public static int GetHeight()
        {
            return graphics.GraphicsDevice.Viewport.Height;
        }

        public static void EnableVSync()
        {
            mg_obj.IsFixedTimeStep = true;
        }

        public static void DisableVSync()
        {
            graphics.SynchronizeWithVerticalRetrace = false;
            mg_obj.IsFixedTimeStep = false;
        }
    }
}
