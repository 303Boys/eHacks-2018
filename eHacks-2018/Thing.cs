using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
	public class Thing
	{
        public Vector2 position; //Thing's position
		public RectangleF colbox; //collision box for Thing
		public Texture2D sprite;
		public string spriteName; //name of Thing's sprite

		public Thing(Vector2 pos, RectangleF rect, string name)
		{
			position = pos;
			colbox = rect;
			spriteName = name;
		}//end Thing constructor

        public Thing(Vector2 pos, RectangleF rect, Texture2D sprite)
        {
            position = pos;
            colbox = rect;
            this.sprite = sprite;
            spriteName = sprite.Name;
        }

        public Vector2 getPosition()
        {
            return this.position;
        }
	}

	public class Wall : Thing
	{
		public Wall(Vector2 pos, RectangleF rect, Texture2D sprite) : base(pos, rect, sprite)
		{
			position = pos;
			colbox = rect;
			this.sprite = sprite;
			spriteName = sprite.Name;
		}
	}
}
