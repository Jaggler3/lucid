using System;
using Mane.GameCore;
using Mane.SubSystems;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;
using Microsoft.Xna.Framework.Input;
using Mane.Control;
using Mane.Foundation;

namespace Mane.Management
{
    class MainState : GameState
    {
        private Hashtable units = new Hashtable();

        public GameData gameData;

        public Vector2 unitSize = new Vector2(GameData.UNIT_SIZE);

        public override void Begin()
        {
            Rendering.BackgroundColor = Color.White;
            Display.ShowMouse();

            gameData = GameData.Create("DevSandbox", GameData.FLAT);

            //Game Data
            for(int i = 0; i < gameData.Units.Count; i++)
            {
                GameObject cu = CreateUnit(gameData.Units[i]);
                Entities.Add(cu);
                units.Add(cu.ObjectID, gameData.Units[i]);
            }

            //Walls
            for (int j = -gameData.Limit / 2; j < gameData.Limit / 2; j++)
            {
                //Left Wall
                GameObject wall_left = CreateWall("wall_left", new Vector2(-gameData.Limit / 2, j) * unitSize, unitSize);
                Entities.Add(wall_left);
                //Right Wall
                GameObject wall_right = CreateWall("wall_right", new Vector2(gameData.Limit / 2 + 1, j) * unitSize, unitSize);
                Entities.Add(wall_right);
            }

            //TODO: top and bottom walls

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

        public GameObject CreateWall(string texture, Vector2 position, Vector2 size)
        {
            GameObject go = new GameObject();
            go.Name = "Wall";
            go.Position = position;
            go.Texture = GameContent.GetTexture(texture);
            go.Size = size;
            go.collider.Static = true;

            return go;
        }

        public GameObject CreateUnit(UnitData unit)
        {
            GameObject go = new GameObject();
            go.Name = "Unit";

            go.Position = unit.Position * GameData.UNIT_SIZE;
            go.Texture = GameContent.GetTexture("units/" + unit.ID);
            go.Size = unitSize;

            go.NewScript("Unit", "Data/unit.lua");

            go.collider.Static = true;

            unit.gameObject = go;

            return go;
        }
    }
}
