using UnityEngine;

namespace Arcade.Scripts.MoveBlockSystem
{
    public interface IMovable
    {
        Vector2 Speed { get; }
        void Move();
    }
}