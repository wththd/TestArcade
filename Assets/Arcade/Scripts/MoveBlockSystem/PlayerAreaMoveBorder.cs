using System;
using Arcade.Scripts.PathPrediction;
using UnityEngine;
using Zenject;

namespace Arcade.Scripts.MoveBlockSystem
{
    [RequireComponent(typeof(EdgeCollider2D))]
    public class PlayerAreaMoveBorder : MonoBehaviour, IPlayerMoveBorder
    {
        [SerializeField] private EdgeCollider2D edgeCollider;
        private IPathPredictor pathPredictor;

        [Inject]
        private void Inject(IPathPredictor pathPredictor)
        {
            this.pathPredictor = pathPredictor;
        }

        private void Awake()
        {
            if (edgeCollider == null) edgeCollider = GetComponent<EdgeCollider2D>();
            pathPredictor.MinYPosition = edgeCollider.bounds.max.y;
        }

        public BlockState CurrentState { get; private set; }

        public void CalculateBlockState(Vector2 position, float radius)
        {
            CurrentState = BlockState.None;

            if (Math.Abs(edgeCollider.bounds.min.x - position.x) < radius) CurrentState |= BlockState.Left;

            if (Math.Abs(edgeCollider.bounds.min.y - position.y) < radius) CurrentState |= BlockState.Down;

            if (Math.Abs(edgeCollider.bounds.max.x - position.x) < radius) CurrentState |= BlockState.Right;

            if (Math.Abs(edgeCollider.bounds.max.y - position.y) < radius) CurrentState |= BlockState.Up;
        }

        public void ClearBlockState()
        {
            CurrentState = BlockState.None;
        }

        public float TopBorderPosition { get; }
    }
}