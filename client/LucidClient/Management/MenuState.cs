using Lucid.GameCore;
using System;
using Microsoft.Xna.Framework;
using Lucid.UI;
using Lucid.SubSystems;
using Lucid.Core;

namespace Lucid.Management
{
    class MenuState : GameState
    {
        public TextDisplay title;
        public Overlay separator;

        public Overlay cover1;
        public Overlay cover2;

        public Button playButton;
        public Button exitButton;

        public TextDisplay infoTop;
        public TextDisplay infoBottom;

        private float fv1 = 1, fv2 = 1;

        public override void Begin()
        {
            Rendering.BackgroundColor = Color.White;

            cover1 = new Overlay(GameContent.GetTexture("white"), Display.GetSize());
            cover2 = new Overlay(GameContent.GetTexture("black"), Display.GetSize());

            title = new TextDisplay("Lucid", Display.GetSize() / 2, 15).Align(TextDisplay.TextAlignment.Right, TextDisplay.TextAlignment.Center);

            infoTop = new TextDisplay("version " + Utilities.GameVersion, new Vector2(5), 3);
            infoBottom = new TextDisplay("@Jaggler3", new Vector2(5, Display.GetHeight() - 5), 3).Align(TextDisplay.TextAlignment.Left, TextDisplay.TextAlignment.Bottom);

            separator = new Overlay(GameContent.GetTexture("black"), new Vector2(10, Display.GetHeight() / 3));
            separator.Position = new Vector2(Display.GetWidth() / 2 - separator.Size.X / 2, Display.GetHeight() / 2);

            playButton = new Button(new Vector2(
                Display.GetWidth() / 2 + separator.Size.X + 5,
                Display.GetHeight() / 2 - 120 - 4)
                , new Vector2(240, 120));

            exitButton = new Button(new Vector2(
                Display.GetWidth() / 2 + separator.Size.X + 5,
                Display.GetHeight() / 2 + 4)
                , new Vector2(240, 120));

            playButton.Text = "Play";
            exitButton.Text = "Exit";

            playButton.FontSize = exitButton.FontSize = 3;
            playButton.TextOffset = exitButton.TextOffset = new Vector2(25, 25);

            playButton.Clicked += Play;
            exitButton.Clicked += Exit;

            playButton.Disabled = exitButton.Disabled = true;

            UserInterface.Add(infoTop);
            UserInterface.Add(infoBottom);

            UserInterface.Add(title);
            UserInterface.Add(separator);

            UserInterface.Add(playButton);
            UserInterface.Add(exitButton);

            UserInterface.Add(cover1);
            UserInterface.Add(cover2);

            Start();
        }

        public void Play()
        {
            Scene.SetState(new MainState());
        }

        public void Exit()
        {
            Display.mg_obj.Exit();
        }

        public override void Refresh(GameTime gameTime)
        {
            cover1.Size = cover2.Size = new Vector2(Display.GetWidth(), Display.GetHeight());

            float _fv1 = Math.Max(fv1, 0), _fv2 = Math.Max(fv2, 0);

            cover1.RenderColor = new Color(_fv2, _fv2, _fv2, _fv2);
            cover2.RenderColor = new Color(Color.White, _fv1);
            if (fv1 > 0) { fv1 -= DeltaTime; } else if (fv2 > 0) { fv2 -= DeltaTime; } else
            {
                playButton.Disabled = exitButton.Disabled = false;
            }

            title.Position = Display.GetSize() / 2;
            separator.Size.Y = Display.GetHeight() / 3;
            separator.Position = new Vector2(Display.GetWidth() / 2 - separator.Size.X / 2, Display.GetHeight() / 2 - separator.Size.Y / 2);
            
            playButton.Position = new Vector2(
                Display.GetWidth() / 2 + separator.Size.X + 5, 
                Display.GetHeight() / 2 - playButton.Size.Y - 4);

            exitButton.Position = new Vector2(
                Display.GetWidth() / 2 + separator.Size.X + 5,
                Display.GetHeight() / 2 + 4);

            Update();
        }

        public override void Terminate()
        {

        }
    }
}
