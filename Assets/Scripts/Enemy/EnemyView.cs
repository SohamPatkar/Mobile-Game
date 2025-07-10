using MobileController.Enemy;
using MobileController.Player;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    private NavMeshAgent navmeshAgent;

    void Start()
    {

    }

    void Update()
    {
        enemyController.Update();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null)
        {
            enemyController.OnEnterRange();
        }
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }

    public void SetController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public NavMeshAgent GetAgent()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
        return navmeshAgent;
    }
}
