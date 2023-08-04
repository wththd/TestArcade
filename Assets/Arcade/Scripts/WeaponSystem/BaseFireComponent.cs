using UnityEngine;

namespace Arcade.Scripts.WeaponSystem
{
    public abstract class BaseFireComponent : MonoBehaviour, ILaunching
    {
        protected float fireRate;
        protected float projectileSpeed;
        protected int weaponDamage;
        public abstract float ProjectileSpeed { get; }
        public abstract Vector2 WeaponPosition { get; }
        public abstract int WeaponDamage { get; }
        public abstract bool CanLaunch();
        public abstract void Launch(Vector3 direction);

        public void Init(float projectileSpeed, float fireRate, int weaponDamage)
        {
            this.projectileSpeed = projectileSpeed;
            this.fireRate = fireRate;
            this.weaponDamage = weaponDamage;
        }
    }
}