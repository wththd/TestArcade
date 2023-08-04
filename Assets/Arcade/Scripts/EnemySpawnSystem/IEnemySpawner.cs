using System.Collections.Generic;
using Arcade.Scripts.Enemy;

namespace Arcade.Scripts.EnemySpawnSystem
{
    public interface IEnemySpawner
    {
        List<EnemyController> Enemies { get; }
        bool CanSpawn();
        EnemyController Spawn();
    }
}