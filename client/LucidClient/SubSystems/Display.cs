using Lucid.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lucid.SubSystems
{
    class Display
    {
        public const int INIT_WIDTH = 1280;
        public const int INIT_HEIGHT = 700;
        public const string TITLE = "Lucid v" + Utilities.GameVersion;

        public static Game mg_obj;
        public static GraphicsDeviceManager graphics;

        public static bool INIT_FULLSCREEN = false;

        public static void Setup(Game _mg, GraphicsDeviceManager _graphics)
        {
            mg_obj = _mg;
            graphics = _graphics;
            SetTitle(TITLE);

            if(INIT_FULLSCREEN)
            {
                DisplayMode _DisplayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
                SetSize(_DisplayMode.Width, _DisplayMode.Height);
                ToggleFullscreen();
            }
            else
            {
                SetSize(INIT_WIDTH, INIT_HEIGHT);
                ShowMouse();
            }
            DisableVSync();
        }

        public static void ShowMouse()
        {
            mg_obj.IsMouseVisible = true;
        }

        public static void HideMouse()
        {
            mg_obj.IsMouseVisible = false;
        }

        public static void ToggleFullscreen()
        {
            graphics.ToggleFullScreen();
        }

        public static Vector2 GetSize()
        {
            return new Vector2(GetWidth(), GetHeight());
        }

        public static void SetSize(Vector2 Size)
        {
            SetSize((int)Size.X, (int)Size.Y);
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
