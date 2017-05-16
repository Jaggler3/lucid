using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
            ShowMouse();
        }

        public static void ShowMouse()
        {
            mg_obj.IsMouseVisible = true;
        }

        public static void HideMouse()
        {
            mg_obj.IsMouseVisible = false;
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
