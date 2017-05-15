using Mane.Core;
using Mane.GameCore;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Mane.SubSystems
{
    class Scene
    {
        private static GameState currentState;

        public static GameTime gameTime;

        public static void Initialize(GameState state)
        {
            currentState = state;
            currentState.Begin();
        }

        public static void SetState(GameState state)
        {
            currentState.Terminate();
            currentState = state;
            currentState.Begin();
        }

        public static void Update(GameTime gameTime)
        {
            Scene.gameTime = gameTime;
            currentState.DeltaTime = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            currentState.Refresh(gameTime);
        }

        public static GameState GetState()
        {
            return currentState;
        }
    }
}
