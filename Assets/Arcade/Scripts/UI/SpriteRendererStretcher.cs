using UnityEngine;

namespace Arcade.Scripts.UI
{
    /// <summary>
    /// Can be used for stretching sprites for different resolutions, in game can be used in awake once
    /// </summary>
    [ExecuteInEditMode]
    public class SpriteRendererStretcher : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera;

        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private Vector2 targetScale;

        private Texture targetTexture;

        private void Awake()
        {
            if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

            targetTexture = spriteRenderer.sprite.texture;
        }

        private void Update()
        {
            if (spriteRenderer == null || targetCamera == null) return;

            var scaleRatio = (float)Screen.height / Screen.width;
            var cameraSizeInWorldSpace = targetCamera.orthographicSize * 2;
            var targetWidth = cameraSizeInWorldSpace / scaleRatio * targetScale.x;
            var targetHeight = cameraSizeInWorldSpace * targetScale.y;
            var spriteWidth = (float)targetTexture.width / 100;
            var spriteHeight = (float)targetTexture.height / 100;

            if (Mathf.Approximately(targetWidth, spriteWidth * transform.localScale.x) &&
                Mathf.Approximately(targetHeight, spriteHeight * transform.localScale.y)) return;

            transform.localScale = new Vector3(targetWidth / spriteWidth, targetHeight / spriteHeight);
        }
    }
}