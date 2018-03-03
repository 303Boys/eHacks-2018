using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace eHacks_2018
{
	public class Level
	{
        private string name { get; set; }
        private Vector2 size { get; set; }
        public List<Thing> thingList = new List<Thing>();
        private List<Vector2> playerSpawns = new List<Vector2>();
        private float gravity { get; set; }
        private List<Player> players = new List<Player>();

		public Level()
		{
            this.name = "The beginning";
            this.size = new Vector2(512, 512);
            this.playerSpawns.Add(new Vector2(512, 512));
            this.gravity = 1;
            this.players.Add(new Player());
		}
	}
}
