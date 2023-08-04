using Arcade.Scripts.HealthSystem;
using UnityEngine;

namespace Arcade.Scripts.WeaponSystem
{
    public abstract class BaseDamageComponent : MonoBehaviour
    {
        public abstract void DealDamage(IHealth target);
    }
}