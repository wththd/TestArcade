using System;
using System.Collections;
using Arcade.Scripts.MoveSystem;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.WeaponSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private BulletMoveTargetComponent moveComponent;
        [SerializeField] 
        private BulletDamageComponent damageComponent;
        
        [Inject]
        private void Inject(Vector3 position, Vector3 target, float speed, int damage)
        {
            transform.position = position;
            moveComponent.Init(target, speed);
            damageComponent.Setup(damage, DestroySelf);
        }

        private void Awake()
        {
            StartCoroutine(DestroyRoutine());
        }

        private IEnumerator DestroyRoutine()
        {
            yield return new WaitForSeconds(5);
            DestroySelf();
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}