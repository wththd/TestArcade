namespace Arcade.Scripts.WinCondition
{
    public class EnemyDiedWinCondition : IWinCondition
    {
        public const string EnemyDieEventName = "EnemyDied";
        private readonly int killsToWin;
        private int enemiesKilled;

        public EnemyDiedWinCondition(int killsToWin)
        {
            this.killsToWin = killsToWin;
        }

        public string EventHandlerName => EnemyDieEventName;


        public void ProcessEvent(string eventName, params object[] payload)
        {
            if (eventName.Equals(EventHandlerName)) AddKillCounter();
        }

        public bool IsDone()
        {
            return enemiesKilled >= killsToWin;
        }

        public void AddKillCounter()
        {
            enemiesKilled++;
        }
    }
}