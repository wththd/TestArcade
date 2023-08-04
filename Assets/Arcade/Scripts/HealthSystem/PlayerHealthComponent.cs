using System;

namespace Arcade.Scripts.HealthSystem
{
    public class PlayerHealthComponent : BaseHealthComponent
    {
        public override int MaxHealth { get; protected set; }
        public override int CurrentHealth { get; protected set; }
        public override event Action Died;
        public virtual event Action<int> HealthChanged;

        public override void DealDamage(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
            {
                Died?.Invoke();
                return;
            }

            HealthChanged?.Invoke(CurrentHealth);
        }

        public override void RestoreHealth(int amount)
        {
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);
        }
    }
}