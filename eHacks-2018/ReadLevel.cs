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

        public void CreateLevel(string filename)
        {
            this.rawLevelData = readFile(filename);

            this.level = new Level(rawLevelData.name, rawLevelData.size, rawLevelData.gravity, rawLevelData.playerSpawns);
        }

        private RawLevelData readFile(string filename)
        {
            RawLevelData rawLevelData;

            StreamReader streamReader = new StreamReader(filename, Encoding.UTF8);
            //Get and store metadata
            string rawMetaData = streamReader.ReadLine();
            var MetaData = rawMetaData.Split(',');

            rawLevelData = new RawLevelData(MetaData[0], new XNAF.Vector2(float.Parse(MetaData[1]), float.Parse(MetaData[2])), float.Parse(MetaData[3]));

            //Get and store player spawn points
            String rawPlayerSpawns = streamReader.ReadLine();
            var playerSpawns = rawPlayerSpawns.Split(',');

            for(int i = 0; i < playerSpawns.Length; i += 2)
            {
                rawLevelData.playerSpawns.Add(new XNAF.Vector2(float.Parse(playerSpawns[i]), float.Parse(playerSpawns[i + 1])));
            }

            //Get and store thing names and positions
            String rawThings = streamReader.ReadLine();
            var things = rawThings.Split(',');

            for(int i = 0; i < things.Length; i += 3)
            {
                rawLevelData.thingNames.Add(things[i]);
                rawLevelData.thingPos.Add(new XNAF.Vector2(float.Parse(things[i + 1]), float.Parse(things[i + 2])));
            }

            return rawLevelData;
        }

        public SpriteBatch loadLevel(SpriteBatch spriteBatch, List<Texture2D> textures)
        {
            return this.level.load(spriteBatch, textures, rawLevelData.thingNames, rawLevelData.thingPos);
        }

        public Level returnLevel()
        {
            return this.level;
        }
    }
}
