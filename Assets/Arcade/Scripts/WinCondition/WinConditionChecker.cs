using System.Collections.Generic;
using System.Linq;
using Arcade.Scripts.Configs;

namespace Arcade.Scripts.WinCondition
{
    public class WinConditionChecker : IWinConditionChecker
    {
        private readonly List<IWinCondition> currentConditions;

        public WinConditionChecker(GameplayConfig gameplayConfig)
        {
            currentConditions = new List<IWinCondition>();
            var enemyDieWinCondition = new EnemyDiedWinCondition(gameplayConfig.EnemyWinCount);
            currentConditions.Add(enemyDieWinCondition);
        }

        public void ProcessEvent(string eventName, params object[] payload)
        {
            foreach (var condition in currentConditions) condition.ProcessEvent(eventName, payload);
        }

        public bool IsGameWon()
        {
            return currentConditions.All(x => x.IsDone());
        }
    }
}