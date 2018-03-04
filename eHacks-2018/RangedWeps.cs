using System;
using System.Drawing;
using Microsoft.Xna.Framework;
namespace eHacks_2018
{
	public class Shooty : ProjectileWeapon
	{
		public Shooty(Vector2 pos, RectangleF rect, string name, int slot) : base(pos, rect, name, slot)
		{
			recoil = 5;
			this.owner = slot;
		}

		public new void use(int facing, Level level)
		{
			Vector2 temp = position;
			if (facing == -1)
			{
				temp.X -= 30f;
			}
			else if (facing == 1)
			{
				temp.X += 30f;
			}
			bullet = new Projectile(temp, new RectangleF(temp.X, temp.Y, 10, 10),
									"bullet", facing, 2f, 70, 50, owner, level);
		}

	}
}
