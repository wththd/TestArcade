using Arcade.Scripts.Enemy;
using Arcade.Scripts.Player;
using Arcade.Scripts.WeaponSystem;
using UnityEngine;

namespace Arcade.Scripts.Containers
{
    [CreateAssetMenu(menuName = "Containers/GameplayPrefabContainer")]
    public class GameplayPrefabContainer : ScriptableObject
    {
        public PlayerController PlayerControllerPrefab;
        public EnemyController EnemyControllerPrefab;
        public Bullet BulletPrefab;
    }
}