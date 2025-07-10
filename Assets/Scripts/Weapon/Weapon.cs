using UnityEngine;
using MobileController.Enemy;

namespace MobileController.Weapon
{
    public class Weapon : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);


            if (collision.gameObject.GetComponent<EnemyView>() != null)
            {
                EnemyView onHit = collision.gameObject.GetComponent<EnemyView>();
                onHit.OnHit();
            }
        }
    }
}


