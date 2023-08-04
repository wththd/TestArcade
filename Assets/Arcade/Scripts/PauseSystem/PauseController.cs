using System.Collections.Generic;

namespace Arcade.Scripts.PauseSystem
{
    public class PauseController : IPauseController
    {
        public List<IPausable> Pausables { get; } = new();

        public void Pause()
        {
            foreach (var pausable in Pausables) pausable.Pause();
        }

        public void Resume()
        {
            foreach (var pausable in Pausables) pausable.Resume();
        }

        public void AddPausable(IPausable pausable)
        {
            Pausables.Add(pausable);
        }

        public void RemovePausable(IPausable pausable)
        {
            Pausables.Remove(pausable);
        }
    }
}