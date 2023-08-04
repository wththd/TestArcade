using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arcade.Scripts.Configs
{
    [Serializable]
    public class EnemyTransformsConfig
    {
        [SerializeField] private List<Transform> enemiesTransforms;

        public List<Transform> EnemiesTransforms => enemiesTransforms;
    }
}