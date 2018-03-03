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
		public Thing()
		{
		}
	}
}
