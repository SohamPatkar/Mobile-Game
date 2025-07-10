using MobileController.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace MobileController.Enemy
{
    public enum State
    {
        IDLE,
        CHASING
    }

    public class EnemyController
    {
        public NavMeshAgent enemyAgent;
        private EnemyView enemyView;
        private EnemySO enemySo;
        private EnemyStateMachine enemyStateMachine;
        private Color enemyColor;

        public EnemyController(EnemyView enemyView, EnemySO enemySO)
        {
            enemySo = enemySO;

            this.enemyView = Object.Instantiate(enemyView.gameObject, enemySO.SpawnPoint, Quaternion.identity).GetComponent<EnemyView>();
            this.enemyView.SetController(this);

            enemyAgent = this.enemyView.GetAgent();

            CreateStateMachine();

            enemyStateMachine.ChangeState(State.IDLE);
        }

        private void CreateStateMachine() => enemyStateMachine = new EnemyStateMachine(this);

        public void Update()
        {
            enemyStateMachine.Update();
        }

        public void OnEnterRange()
        {
            enemyStateMachine.ChangeState(State.CHASING);
        }

        public void MoveToPlayer()
        {
            enemyAgent.SetDestination(GameManager.Instance.GetPlayer().gameObject.transform.position);
        }

    }
}


