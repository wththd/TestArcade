using System;
using UnityEngine;

namespace Arcade.Scripts.EventListeners
{
    public abstract class BaseTriggerListener<T> : MonoBehaviour, ITriggerEventListener<T>
    {
        public abstract event Action<T> OnTriggerEnter;
        public abstract event Action<T> OnTriggerLeave;
    }
}