using MobileController.Enemy;
using MobileController.Player;
using UnityEngine;

namespace MobileController.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private EnemyView enemyView;
        [SerializeField] private EnemySO[] enemySO;
        [SerializeField] private PlayerView playerView;
        private static GameManager instance;

        public static GameManager Instance { get { return instance; } }
        public PlayerView PlayerView { get { return playerView; } }


        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            CreateEnemy();
        }

        public PlayerView GetPlayer()
        {
            return PlayerView;
        }

        private void CreateEnemy()
        {
            foreach (EnemySO enemy in enemySO)
            {
                EnemyController enemyController = new EnemyController(enemyView, enemy);
            }
        }
    }
}


