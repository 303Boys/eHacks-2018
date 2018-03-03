using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
	public class Weapon : Thing
	{
        protected int knockback;
        protected int damage;
        protected int recoil;
        protected int cooldownTime;
        protected int weight;

		public Weapon()
		{

		}

        public void use()
        {

        }

        int cooldownTimer(int cooldownTime)
        {
            while(cooldownTime > 0) { cooldownTime--; }
            return 0;
        }
    }

    public class MeleeWeapon : Weapon
    {
        protected int swingRate;

        public MeleeWeapon()
        {

        }
    }

    public class ProjectileWeapon : Weapon
    {

        protected int maxAmmo;
        protected int curAmmo;
        protected Projectile ProjectileType;
        protected int fireRate;
        protected double angle;

        public ProjectileWeapon()
        {

        }
    }

    public class Projectile : Thing
    {
        private float speed;
        private int duration;
        private int damage;

        public Projectile()
        {

        }

        public void Countdown(int duration)
        {
            while(duration >= 0) {duration--;}
        }
    }
}
