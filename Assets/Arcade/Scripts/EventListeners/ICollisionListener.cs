using System;

namespace Arcade.Scripts.EventListeners
{
    public interface ICollisionListener<T>
    {
        event Action<T> OnCollisionEnter;
        event Action<T> OnCollisionLeave;
        event Action<T> OnCollisionStay;
    }
}