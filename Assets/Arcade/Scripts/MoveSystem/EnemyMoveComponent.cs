using Arcade.Scripts.InputSystem;

namespace Arcade.Scripts.MoveSystem
{
    public class EnemyMoveComponent : BaseMoveComponent
    {
        protected override void Awake()
        {
            base.Awake();
            inputController = new EnemyInputController();
        }
    }
}