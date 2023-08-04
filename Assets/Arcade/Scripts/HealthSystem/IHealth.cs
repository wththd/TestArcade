using System;

namespace Arcade.Scripts.HealthSystem
{
    public interface IHealth
    {
        event Action Died;
        int MaxHealth { get; }
        int CurrentHealth { get; }
        void DealDamage(int amount);
        void RestoreHealth(int amount);
    }
}