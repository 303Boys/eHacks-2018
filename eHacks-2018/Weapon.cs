using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
    public class Weapon : Thing
    {

        //Attributes of Weapon class
        protected int knockback;
        protected int damage;
        protected int recoil;
        protected int cooldownTime;
        protected int weight;


        //Constructor for Weapon class
        public Weapon(Vector2 pos, RectangleF rect, string name) : base(pos, rect, name)
        {
            knockback = 0;
            damage = 0;
            recoil = 0;
            cooldownTime = 0;
            weight = 0;
        }
//--------------------------------------------------------------------------------------------------------------
        // Getters for Weapon Attributes
        public int Getknockback()
        {
            return knockback;
        }
        public int Getdamage()
        {
            return damage;
        }
        public int Getrecoil()
        {
            return recoil;
        }
        public int Getcooldowntime()
        {
            return cooldownTime;
        }
        public int Getweight()
        {
            return weight;
        }
//--------------------------------------------------------------------------------------------------------------
        // Setters for Weapon Attributes
        public void Setknockback(int X)
        {
            knockback = X;
        }
        public void Setdamage(int X)
        {
            damage = X;
        }
        public void Setrecoil(int X)
        {
            recoil = X;   
        }
        public void Setcooldowntime(int X)
        {
            cooldownTime = X;
        }
        public void Setweight(int X)
        {
            weight = X;
        }

        public void use(int direction)
        {

        }

        int cooldownTimer(int cooldownTime)
        {
            while (cooldownTime > 0) { cooldownTime--; }
            return 0;
        }
    }

    public class MeleeWeapon : Weapon
    {
        protected int swingRate;

        public MeleeWeapon(Vector2 pos, RectangleF rect, string name) : base(pos, rect, name)
        {
            swingRate = 0;
        }
        public int GetswingRate()
        {
            return swingRate;
        }
        public void SetswingRate(int X)
        {
            swingRate = X;
        }
    }

    public class ProjectileWeapon : Weapon
    {

        protected int maxAmmo;
        protected int curAmmo;
        protected Projectile bullet;
        protected int fireRate;
        protected double angle;

        public ProjectileWeapon(Vector2 pos, RectangleF rect, string name) : base(pos, rect, name)
        {
            maxAmmo = 0;
            curAmmo = maxAmmo;
			bullet = new Projectile(position, new RectangleF(position.X, position.Y, 10, 10), "bullet");
            fireRate = 0;
            angle = 0;
        }
        //--------------------------------------------------------------------------------------------------------------
        // Getters for ProjectileWeapon Attributes
        public int GetmaxAmmo()
        {
            return maxAmmo;
        }
        public int GetcurAmmo()
        {
            return curAmmo;
        }
        public Projectile GetProjectileType()
        {
            return bullet;
        }
        public int GetfireRate()
        {
            return fireRate;
        }
        public double Getangle()
        {
            return angle;
        }
        //--------------------------------------------------------------------------------------------------------------
        // Setters for ProjectileWeapon Attributes
        public void SetmaxAmmo(int X)
        {
            maxAmmo = X;
        }
        public void SetcurAmmo(int X)
        {
            curAmmo = X;
        }
        public void SetProjectileType(Projectile X)
        {
            bullet = X;
        }
        public void SetfireRate(int X)
        {
            fireRate = X;
        }
        public void Setangle(double X)
        {
            angle = X;
        }

		public override void use(int direction)
		{
			
		}

    }

    public class Projectile : Thing
    {
        private float speed;
        private int duration;
        private int damage;

        public Projectile(Vector2 pos, RectangleF rect, string name) : base(pos, rect, name)
        {
			speed = 80f;
            duration = 20;
            damage = 10;
        }

        public float Getspeed()
        {
            return speed;
        }
        public int Getduration()
        {
            return duration;
        }
        public int Getdamage()
        {
            return damage;
        }

        public void Setspeed(float X)
        {
            speed = X;
        }
        public void Setduration(int X)
        {
            duration = X;
        }
        public void Setdamage(int X)
        {
            damage = X;
        }


        public void Countdown(int duration)
        {
            while (duration >= 0) { duration--; }
        }
    }
}
