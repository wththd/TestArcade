using UnityEngine;

namespace Arcade.Scripts.WeaponSystem
{
    public interface ILaunching
    {
        bool CanLaunch();
        void Launch(Vector3 direction);
    }
}