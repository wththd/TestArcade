namespace Arcade.Scripts.WinCondition
{
    public interface IWinConditionChecker
    {
        void ProcessEvent(string eventName, params object[] payload);
        bool IsGameWon();
    }
}