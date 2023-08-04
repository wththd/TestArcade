using System;
using System.Reflection;
using Arcade.Scripts.Configs;
using Arcade.Scripts.Extensions;
using UnityEngine;
using Zenject;
using IValidatable = Arcade.Scripts.Configs.IValidatable;

namespace Arcade.Scripts.Installers
{
    [CreateAssetMenu(menuName = "Installers/ConfigInstaller", fileName = "ConfigScriptableObjectInstaller")]
    public class ConfigScriptableObjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] 
        private EnemyInitialConfig enemyConfig;
        [SerializeField] 
        private GameplayConfig gameplayConfig;
        [SerializeField] 
        private PlayerConfig playerConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(enemyConfig);
            Container.BindInstance(gameplayConfig);
            Container.BindInstance(playerConfig);
        }

        private void OnValidate()
        {
            const BindingFlags bindingFlags = BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Instance |
                                              BindingFlags.Static;
            
            foreach (var field in GetType().GetFields(bindingFlags))
            {
                if (field.FieldType.ImplementsInterface(typeof(IValidatable)))
                {
                    var iValidatable = (IValidatable)field.GetValue(this);
                    iValidatable.Validate();
                }
            }
        }
    }
}