using Mane.SubSystems;
using Mane.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Mane.GameCore
{
    abstract class GameState
    {
        public float DeltaTime = 0.01f;
        private ContentManager Content = Rendering.Content;
        public List<GameObject> Entities = new List<GameObject>();
        public List<UIObject> UserInterface = new List<UIObject>();

        public abstract void Begin();
        public void Start()
        {
            for (var i = 0; i < Entities.Count; i++)
            {
                Entities[i].Start();
            }
        }
        public abstract void Refresh(GameTime gameTime);
        public void Update()
        {
            for(var i = 0; i < Entities.Count; i++)
            {
                Entities[i].Update();
            }

            for (var i = 0; i < UserInterface.Count; i++)
            {
                UserInterface[i].Update();
            }
        }
        public abstract void Terminate();
    }
}
