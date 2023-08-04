using System;
using UnityEngine;

namespace Arcade.Scripts.EventListeners
{
    public class Collision2DEventListener : BaseCollisionListener<Collision2D>
    {
        public override event Action<Collision2D> OnCollisionEnter;
        public override event Action<Collision2D> OnCollisionLeave;
        public override event Action<Collision2D> OnCollisionStay;

        public void OnCollisionEnter2D(Collision2D other)
        {
            OnCollisionEnter?.Invoke(other);
        }

        public void OnCollisionExit2D(Collision2D other)
        {
            OnCollisionLeave?.Invoke(other);
        }

        public void OnCollisionStay2D(Collision2D other)
        {
            OnCollisionStay?.Invoke(other);
        }
    }
}