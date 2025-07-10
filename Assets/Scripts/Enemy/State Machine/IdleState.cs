using UnityEngine;

namespace MobileController.Enemy
{
    public class IdleState : IState
    {
        public EnemyController enemyController { get; set; }

        private EnemyStateMachine enemyStateMachine;

        public IdleState(EnemyStateMachine enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
        }

        public void OnEnterState()
        {

        }

        public void OnExitState()
        {

        }

        public void OnUpdate()
        {

        }
    }

}

