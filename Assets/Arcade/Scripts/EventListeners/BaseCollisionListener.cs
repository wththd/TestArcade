using System;
using UnityEngine;

namespace Arcade.Scripts.EventListeners
{
    public abstract class BaseCollisionListener<T> : MonoBehaviour, ICollisionListener<T>
    {
        public abstract event Action<T> OnCollisionEnter;
        public abstract event Action<T> OnCollisionLeave;
        public abstract event Action<T> OnCollisionStay;
    }
}