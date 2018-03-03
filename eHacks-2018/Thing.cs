using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
	public class Thing
	{
		protected Vector2 position; //Thing's position
		protected RectangleF colbox; //collision box for Thing
		public Texture2D sprite;
		public string spriteName; //name of Thing's sprite

		public Thing(Vector2 pos, RectangleF rect, string name)
		{
			position = pos;
			colbox = rect;
			spriteName = name;
		}//end Thing constructor
	}
}
