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
            knockback = 0;
            damage = 0;
            recoil = 0;
            cooldownTime = 0;
            weight = 0;
        }

        public void use()
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

        public MeleeWeapon()
        {
            swingRate = 0;
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
            maxAmmo = 0;
            curAmmo = maxAmmo;
           // ProjectileType = ;
            fireRate = 0;
            angle = 0;
        }
    }

    public class Projectile : Thing
    {
        private float speed;
        private int duration;
        private int damage;

        public Projectile()
        {
            speed = 0;
            duration = 0;
            damage = 0;
        }

        public void Countdown(int duration)
        {
            while (duration >= 0) { duration--; }
        }
    }
}
