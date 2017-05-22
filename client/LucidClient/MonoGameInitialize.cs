using Lucid.GameCore;
using Lucid.Management;
using Lucid.SubSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;

namespace Lucid
{
    public class MonoGameInitialize : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameState INIT_STATE = new StartState();

        public MonoGameInitialize()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Display.Setup(this, graphics);
        }

        protected override void Initialize()
        {
            Rendering.Content = Content;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Load Game Files
            for (int i = 0; i < GameContent.TextureNames.Length; i++) // textures
            {
                GameContent.LoadedTextures[i] = Content.Load<Texture2D>(GameContent.TextureNames[i]);
            }
            for (int i = 0; i < GameContent.FontNames.Length; i++) // fonts
            {
                GameContent.LoadedFonts[i] = Content.Load<SpriteFont>(GameContent.FontNames[i]);
            }

            //Start first gamestate
            Scene.Initialize(INIT_STATE);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here

            Scene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Rendering.BackgroundColor);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            var entity_list = Scene.GetState().Entities;
            for (int i = 0; i < entity_list.Count; i++)
            {
                entity_list[i].Render(spriteBatch);
            }

            spriteBatch.End(); //Start a new SpriteBatch so that previous shaders and layering does not apply to the UI
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            var ui_list = Scene.GetState().UserInterface;
            for (int i = 0; i < ui_list.Count; i++)
            {
                ui_list[i].Render(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
