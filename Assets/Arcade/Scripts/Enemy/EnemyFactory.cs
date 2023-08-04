using UnityEngine;
using Zenject;

namespace Arcade.Scripts.Enemy
{
    public class EnemyFactory : PlaceholderFactory<float, int, Sprite, EnemyController>
    {
    }
}