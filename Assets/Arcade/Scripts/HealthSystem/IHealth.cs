using System;

namespace Arcade.Scripts.HealthSystem
{
    public interface IHealth
    {
        int MaxHealth { get; }
        int CurrentHealth { get; }
        event Action Died;
        void DealDamage(int amount);
        void RestoreHealth(int amount);
    }
}