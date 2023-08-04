using Arcade.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.WeaponSystem
{
    public class FireComponent : BaseFireComponent
    {
        public override float ProjectileSpeed => projectileSpeed;
        public override Vector2 WeaponPosition => weaponTransformPosition.position;
        public override int WeaponDamage => weaponDamage;

        private BulletFactory bulletFactory;
        private float lastShotTime;

        [SerializeField]
        private Transform weaponTransformPosition;
        
        [Inject]
        private void Inject(BulletFactory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
        }

        public override bool CanLaunch()
        {
            return Time.unscaledTime - lastShotTime > fireRate;
        }

        public override void Launch(Vector3 direction)
        {
            bulletFactory.Create(weaponTransformPosition.position, direction, ProjectileSpeed, WeaponDamage);
            lastShotTime = Time.unscaledTime;
        }
    }
}