namespace Arcade.Scripts.WinCondition
{
    public interface IWinCondition
    {
        string EventHandlerName { get; }
        void ProcessEvent(string eventName, params object[] payload);
        bool IsDone();
    }
}