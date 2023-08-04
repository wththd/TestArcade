using System.Collections.Generic;

namespace Arcade.Scripts.PauseSystem
{
    public interface IPauseController
    {
        List<IPausable> Pausables { get; }
        void Pause();
        void Resume();
        void AddPausable(IPausable pausable);
        void RemovePausable(IPausable pausable);
    }
}