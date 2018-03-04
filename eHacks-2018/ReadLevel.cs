using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using XNAF = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace eHacks_2018
{
    class ReadLevel
    {
        private RawLevelData rawLevelData;
        private Level level;

        public ReadLevel()
        {

        }

        public void CreateLevel(string filename, List<Texture2D> textures)
        {
            this.rawLevelData = readFile(filename);

            this.level = new Level(rawLevelData.name, rawLevelData.size, rawLevelData.gravity, rawLevelData.playerSpawns);
            this.level.loadThings(textures, rawLevelData.spriteNames, rawLevelData.thingPos, rawLevelData.thingTypes);
        }

        private RawLevelData readFile(string filename)
        {
            RawLevelData rawLevelData;

            StreamReader streamReader = new StreamReader(filename, Encoding.UTF8);

            //Get and store metadata
            var rawMetaData = streamReader.ReadLine().Split(',');

            rawLevelData = new RawLevelData(rawMetaData[0], new XNAF.Vector2(float.Parse(rawMetaData[1]), float.Parse(rawMetaData[2])), float.Parse(rawMetaData[3]));

            //Get and store player spawn points
            var rawPlayerSpawns = streamReader.ReadLine().Split(',');

            for(int i = 0; i < rawPlayerSpawns.Length; i += 2)
            {
                rawLevelData.playerSpawns.Add(new XNAF.Vector2(float.Parse(rawPlayerSpawns[i]), float.Parse(rawPlayerSpawns[i + 1])));
            }

            //Get and store thing names and positions
            var rawThings = streamReader.ReadLine().Split(',');

            for(int i = 0; i < rawThings.Length; i += 4)
            {
                rawLevelData.thingTypes.Add(int.Parse(rawThings[i]));
                rawLevelData.spriteNames.Add(rawThings[i + 1]);
                rawLevelData.thingPos.Add(new XNAF.Vector2(float.Parse(rawThings[i + 2]), float.Parse(rawThings[i + 3])));
            }

            var rawDoorName = streamReader.ReadLine().Split(',');
            rawLevelData.spriteNames.Add(rawDoorName[0]);

            return rawLevelData;
        }

        public Level returnLevel()
        {
            return this.level;
        }
    }
}
