using UnityEngine;

namespace Arcade.Scripts.UI
{
    /// <summary>
    /// Can be used for settings position in screen space for different resolutions, in game can be used in awake once
    /// </summary>
    [ExecuteInEditMode]
    public class TransformPositionSetter : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera;

        [SerializeField] private Vector2 targetPosition;

        private Transform cachedTransform;

        private void Awake()
        {
            cachedTransform = transform;
        }

        private void Update()
        {
            if (targetCamera == null) return;

            var targetWorldPosition = targetCamera.ScreenToWorldPoint(new Vector3(Screen.width * targetPosition.x,
                Screen.height * targetPosition.y, 0));
            if (targetWorldPosition != cachedTransform.position)
            {
                targetWorldPosition.z = 0;
                cachedTransform.position = targetWorldPosition;
            }
        }
    }
}