using System;
using System.Drawing;
using XNAF = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace eHacks_2018
{
    public class RawLevelData
    {
        public string name;
        public XNAF.Vector2 size;
        public float gravity;
        public List<string> thingNames = new List<string>();
        public List<XNAF.Vector2> thingPos = new List<XNAF.Vector2>();
        public List<XNAF.Vector2> playerSpawns = new List<XNAF.Vector2>();

        public RawLevelData(string name, XNAF.Vector2 size, float gravity)
        {
            this.name = name;
            this.size = size;
            this.gravity = gravity;
        }

        public RawLevelData(string name, XNAF.Vector2 size, float gravity, List<string> thingNames, List<XNAF.Vector2> thingPos)
        {
            this.name = name;
            this.size = size;
            this.gravity = gravity;
            this.thingNames = thingNames;
            this.thingPos = thingPos;
        }
    }

	public class Level
	{
        private string name { get; set; }
        private XNAF.Vector2 size { get; set; }
        public List<Thing> thingList;
        private List<XNAF.Vector2> playerSpawns;
        private float gravity { get; set; }
        private List<Player> players = new List<Player>();

		public Level(string name, XNAF.Vector2 size, float gravity, List<XNAF.Vector2> playerSpawns)
		{
            this.name = name;
            this.size = size;
            this.playerSpawns = playerSpawns;
            this.players.Add(new Player(playerSpawns[0], new RectangleF(playerSpawns[0].X, playerSpawns[0].Y, 25, 25), "Player1"));
		}

        public SpriteBatch load(SpriteBatch spriteBatch, List<Texture2D> textures, List<string> thingNames, List<XNAF.Vector2> thingPos)
        {
            this.thingList = loadThings(textures, thingNames, thingPos);

            spriteBatch.Begin();
            spriteBatch.Draw(thingList[0].sprite, thingList[0].getPosition(), XNAF.Color.White);
            spriteBatch.End();

            return spriteBatch;
        }

        private List<Thing> loadThings(List<Texture2D> textures, List<string> thingNames, List<XNAF.Vector2> thingPos)
        {
            thingList = new List<Thing>();

            for(int i = 0; i < thingNames.Count; i++)
            {
                thingList.Add(new Thing(thingPos[i], new RectangleF(playerSpawns[0].X, playerSpawns[0].Y, 25, 25), textures[0]));
            }

            return thingList;
        }
	}
}
