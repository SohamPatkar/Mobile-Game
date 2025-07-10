using UnityEngine;

namespace MobileController.Enemy
{
    public class ChaseState : IState
    {
        public EnemyController enemyController { get; set; }

        private EnemyStateMachine enemyStateMachine;

        public ChaseState(EnemyStateMachine enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
        }

        public void OnEnterState()
        {
            enemyController.MoveToPlayer();
        }

        public void OnExitState()
        {

        }

        public void OnUpdate()
        {
            if (enemyController.enemyAgent.isStopped)
            {
                enemyStateMachine.ChangeState(State.IDLE);
            }
        }
    }
}
