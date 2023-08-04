using System;
using UnityEngine;

namespace Arcade.Scripts.EventListeners
{
    public interface ITriggerEventListener<T>
    {
        event Action<T> OnTriggerEnter;
        event Action<T> OnTriggerLeave;
    }
}