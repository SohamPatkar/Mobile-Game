namespace MobileController.Enemy
{
    public interface IState
    {
        public EnemyController enemyController { get; set; }

        void OnEnterState();
        void OnExitState();
        void OnUpdate();

    }
}


