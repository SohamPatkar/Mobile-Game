using System.Collections.Generic;

namespace MobileController.Enemy
{
    public class EnemyStateMachine
    {
        private EnemyController enemyController;
        protected Dictionary<State, IState> States = new Dictionary<State, IState>();
        private IState currentState;

        public EnemyStateMachine(EnemyController enemyController)
        {
            this.enemyController = enemyController;

            AddStates();
            SetOwner();
        }

        private void AddStates()
        {
            States.Add(State.IDLE, new IdleState(this));
            States.Add(State.CHASING, new ChaseState(this));
        }

        private void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.enemyController = enemyController;
            }
        }

        public void Update()
        {
            currentState?.OnUpdate();
        }

        private void ChangeState(IState state)
        {
            currentState?.OnExitState();
            currentState = state;
            currentState?.OnEnterState();
        }

        public void ChangeState(State newState) => ChangeState(States[newState]);
    }
}


