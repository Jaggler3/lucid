using Mane.GameCore;
using System;
using Microsoft.Xna.Framework;
using Mane.SubSystems;

namespace Mane.Management
{
    class StartState : GameState
    {
        public int[] Lengths = new int[]
        {
            3,
            3
        };

        private int displayIndex = 0;

        private float fInTimer = 0.0f;
        private float fOutTimer = 0.0f;
        private float hTimer = 0.0f;

        private static int F_I = 0;
        private static int HOLD = 1;
        private static int F_O = 2;
        private int state = F_I;

        private float opacity = 0;

        private float fwt = 0, fwtl = 0.5f;

        public override void Begin()
        {
            Entities.Add(CreateSplash("splash/dev"));
            Entities.Add(CreateSplash("splash/monogame"));

            Start();
        }

        private GameObject CreateSplash(string path)
        {
            GameObject go = new GameObject("Splash", path);
            go.RenderColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

            return go;
        }

        public override void Refresh(GameTime gameTime)
        {
            float delta = gameTime.ElapsedGameTime.Milliseconds / 1000f;

            if(fwt < fwtl) { fwt += delta; return; }

            if (displayIndex < Entities.Count)
            {
                Entities[displayIndex].RenderColor = new Color(opacity, opacity, opacity, 1);
                if (state == F_I)
                {
                    if(fInTimer > 1.0f)
                    {
                        state = HOLD;
                        fInTimer = 0;
                        opacity = 1.0f;
                    }
                    else
                    {
                        fInTimer += delta;
                        opacity = fInTimer;
                    }
                }
                else if(state == HOLD)
                {
                    if (hTimer > Lengths[displayIndex])
                    {
                        state = F_O;
                        hTimer = 0;
                    }
                    else
                    {
                        hTimer += delta;
                        opacity = 1.0f;
                    }
                }
                else if (state == F_O)
                {
                    if (fOutTimer > 1)
                    {
                        state = F_I;
                        fOutTimer = 0;
                        opacity = 0.0f;
                        displayIndex++;
                    }
                    else
                    {
                        fOutTimer += delta;
                        opacity = 1 - fOutTimer;
                    }
                }
            }
            else
            {
                Scene.SetState(new MenuState());
            }

            Update();
        }

        public override void Terminate()
        {

        }
    }
}
