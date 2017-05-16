using System;
using Mane.GameCore;
using Mane.SubSystems;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Mane.Control;

namespace Mane.Management
{
    class TestState : GameState
    {
        public List<GameObject> units = new List<GameObject>();

        public int unitCountWide = 20;
        public int unitCountDeep = 24;
        public int wallHeight = 24;

        public Vector2 unitSize = new Vector2(Player.unitScale, Player.unitScale);

        public override void Begin()
        {
            for(int i = 0; i < unitCountWide; i++)
            {
                for (int j = 0; j < unitCountDeep; j++)
                {
                    GameObject unit = CreateUnit("unit", new Vector2(i * unitSize.X - unitSize.X * unitCountWide / 2, -j * unitSize.Y), unitSize);
                    Entities.Add(unit);
                }
            }

            Entities.Add(Player.Initialize());

            //Initialize Game State
            Start();
        }

        public override void Refresh(GameTime gameTime)
        {
            Player.Update(gameTime);

            //Update Game State
            Update();
        }

        public override void Terminate()
        {

        }

        public GameObject CreateUnit(string texture, Vector2 position, Vector2 size)
        {
            GameObject go = new GameObject();
            go.Name = "Unit";
            go.Position = position;
            go.Texture = GameContent.GetTexture("unit");
            go.Size = size;

            go.NewScript("Unit", "Lua/unit.lua");

            go.collider.Static = true;

            return go;
        }
    }
}
