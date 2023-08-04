using System;

namespace Arcade.Scripts.MoveBlockSystem
{
    [Flags]
    public enum BlockState
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 4,
        Down = 8
    }
}