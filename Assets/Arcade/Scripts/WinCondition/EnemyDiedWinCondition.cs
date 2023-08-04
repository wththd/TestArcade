namespace Arcade.Scripts.WinCondition
{
    public class EnemyDiedWinCondition : IWinCondition
    {
        public string EventHandlerName => EnemyDieEventName;

        public const string EnemyDieEventName = "EnemyDied";
        private int enemiesKilled;
        private int killsToWin;

        public EnemyDiedWinCondition(int killsToWin)
        {
            this.killsToWin = killsToWin;
        }

        public void AddKillCounter()
        {
            enemiesKilled++;
        }


        public void ProcessEvent(string eventName, params object[] payload)
        {
            if (eventName.Equals(EventHandlerName))
            {
                AddKillCounter();
            }
        }

        public bool IsDone()
        {
            return enemiesKilled >= killsToWin;
        }
    }
}