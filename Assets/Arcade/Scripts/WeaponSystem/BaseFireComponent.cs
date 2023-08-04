using UnityEngine;

namespace Arcade.Scripts.WeaponSystem
{
    public abstract class BaseFireComponent : MonoBehaviour, ILaunching
    {
        public abstract float ProjectileSpeed { get; }
        public abstract Vector2 WeaponPosition { get; }
        public abstract int WeaponDamage { get; }
        protected float projectileSpeed;
        protected float fireRate;
        protected int weaponDamage;
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