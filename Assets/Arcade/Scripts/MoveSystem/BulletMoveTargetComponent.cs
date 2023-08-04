using UnityEngine;

namespace Arcade.Scripts.MoveSystem
{
    public class BulletMoveTargetComponent : MonoBehaviour
    {
        private Transform cachedTransform;
        private Vector3 moveDirection = Vector3.negativeInfinity;
        public float Speed { get; private set; }

        private void Awake()
        {
            cachedTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            if (moveDirection == Vector3.negativeInfinity) return;


            cachedTransform.position += moveDirection * (Speed * Time.deltaTime);
        }

        public void Init(Vector3 target, float speed)
        {
            moveDirection = (target - transform.position).normalized;
            Speed = speed;
        }
    }
}