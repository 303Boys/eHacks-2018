using System;
using System.Drawing;
using XNAF = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace eHacks_2018
{
	public class Level
	{
        private string name { get; set; }
        private XNAF.Vector2 size { get; set; }
        public List<Thing> thingList;
        private List<XNAF.Vector2> playerSpawns = new List<XNAF.Vector2>();
        private float gravity { get; set; }
        public List<Player> players = new List<Player>();

		public Level()
		{
            this.name = "The beginning";
            this.size = new XNAF.Vector2(512, 512);
            this.playerSpawns.Add(new XNAF.Vector2(0, 0));
            this.gravity = 1;
			this.players.Add(new Player(playerSpawns[0], new RectangleF(playerSpawns[0].X, playerSpawns[0].Y, 25, 25), "player1"));
		}

        public SpriteBatch load(SpriteBatch spriteBatch, List<Texture2D> textures)
        {
            this.thingList = loadThings(textures);

            spriteBatch.Begin();
            spriteBatch.Draw(thingList[0].sprite, thingList[0].getPosition(), XNAF.Color.White);
			spriteBatch.Draw(players[0].sprite, players[0].getPosition(), XNAF.Color.White);
            spriteBatch.End();

            return spriteBatch;
        }

        private List<Thing> loadThings(List<Texture2D> textures)
        {
            thingList = new List<Thing>();
			players[0].sprite = textures[0];
            for(int i = 0; i < textures.Count; i++)
            {
                thingList.Add(new Thing(new XNAF.Vector2(125, 300), new RectangleF(125, 300, 25, 25), textures[0]));
            }

            return thingList;
        }
	}
}
