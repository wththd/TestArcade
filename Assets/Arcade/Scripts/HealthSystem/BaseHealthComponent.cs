using System;
using UnityEngine;

namespace Arcade.Scripts.HealthSystem
{
    public abstract class BaseHealthComponent : MonoBehaviour, IHealth
    {
        public abstract event Action Died;
        public abstract int MaxHealth { get; protected set; }
        public abstract int CurrentHealth { get; protected set; }
        public abstract void DealDamage(int amount);
        public abstract void RestoreHealth(int amount);
        
        public virtual void Setup(int maxHealth)
        {
            MaxHealth = CurrentHealth = maxHealth;
        }
    }
}