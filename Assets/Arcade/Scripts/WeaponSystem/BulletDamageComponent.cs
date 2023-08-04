using System;
using Arcade.Scripts.EventListeners;
using Arcade.Scripts.HealthSystem;
using UnityEngine;

namespace Arcade.Scripts.WeaponSystem
{
    public class BulletDamageComponent : BaseDamageComponent
    {
        [SerializeField] private BaseCollisionListener<Collision2D> collisionListener;

        private int damage;
        private Action OnDamageDealt;

        public void Setup(int damage, Action onDealDamage)
        {
            this.damage = damage;
            OnDamageDealt = onDealDamage;

            collisionListener.OnCollisionEnter += OnCollisionEntered;
        }

        private void OnCollisionEntered(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IHealth target)) DealDamage(target);
        }

        public override void DealDamage(IHealth target)
        {
            target.DealDamage(damage);
            OnDamageDealt?.Invoke();
        }
    }
}