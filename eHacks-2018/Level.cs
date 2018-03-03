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
        public List<Player> players = new List<Player>();

		public Level(string name, XNAF.Vector2 size, float gravity, List<XNAF.Vector2> playerSpawns)
		{
            this.name = name;
            this.size = size;
            this.playerSpawns = playerSpawns;
            this.players.Add(new Player(playerSpawns[0], new RectangleF(playerSpawns[0].X, playerSpawns[0].Y, 25, 25), "Player1"));
		}

        public SpriteBatch draw(SpriteBatch spriteBatch, List<Texture2D> textures)
        {
            spriteBatch.Begin();
            for(int i = 0; i < thingList.Count; i++)
            {
                spriteBatch.Draw(thingList[i].sprite, thingList[i].getPosition(), XNAF.Color.White);
            }
            for(int i = 0; i < players.Count; i++)
            {
                spriteBatch.Draw(players[i].sprite, players[i].getPosition(), XNAF.Color.White);
            }
            spriteBatch.End();

            return spriteBatch;
        }

        public void loadThings(List<Texture2D> textures, List<string> thingNames, List<XNAF.Vector2> thingPos)
        {
            thingList = new List<Thing>();
            players[0].sprite = textures[0];
            for(int i = 0; i < thingNames.Count; i++)
            {
				thingList.Add(new Thing(thingPos[i], new RectangleF(thingPos[i].X, thingPos[i].Y, 25, 25), textures[0]));
            }
        }
	}
}
