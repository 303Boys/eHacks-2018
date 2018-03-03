using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
	public class Weapon : Thing
	{
		public Weapon(Vector2 pos, RectangleF rect, string name) : base(pos, rect, name)
		{
		}
	}
}
