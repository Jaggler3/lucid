using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mane.Foundation
{
    class GameData
    {
        public const int UNIT_SIZE = 80; //size in pixels of a singular unit
        public static int
            FLAT = 0,           //provides a ground that you can work with
            NOISE = 1,          //provides a random perlin-noise based game
            FULL = 2;           //provides a NOISE game with built in example objects to interact with

        public List<UnitData> Units;
        private string _name = "Lonely";

        public int Limit = 24;       //the size of the world (length & height)

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public GameData(string Name)
        {
            _name = Name;
            Units = new List<UnitData>();
        }

        public static GameData Create(string Name, int Type)
        {
            GameData data = new GameData(Name);

            if(Type == FLAT)
            {
                List<UnitData> _u = new List<UnitData>();

                Vector2 origin = new Vector2(-data.Limit / 2, -data.Limit / 2);
                for(int i = 0; i <= data.Limit; i++)
                {
                    for (int j = 0; j <= data.Limit / 2; j++)
                    {
                        UnitData tu = new UnitData(); //tu : this unit :P

                        //tu.ID = "unit"; //"unit" is the default ID, it doesn't need to be set
                        tu.Position = origin + new Vector2(i, j);

                        _u.Add(tu);
                    }
                }
                
                data.Units = _u;
            }

            Console.WriteLine(data.Units.Count);

            return data;
        }
    }
}
