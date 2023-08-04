using System;
using UnityEngine;

namespace Arcade.Scripts.EventListeners
{
    public class Trigger2DEventListener : BaseTriggerListener<Collider2D>
    {
        public override event Action<Collider2D> OnTriggerEnter;
        public override event Action<Collider2D> OnTriggerLeave;
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnter?.Invoke(other);
        }
        
        protected void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerLeave?.Invoke(other);
        }
    }
}