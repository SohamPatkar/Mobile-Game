using UnityEngine;

namespace MobileController.Player
{
    [CreateAssetMenu(menuName = "Player SO")]
    public class PlayerScriptableObject : ScriptableObject
    {
        [Header("Should be between 2-5")]
        public float PlayerSpeed;

        [Header("Should be between 15-20")]
        public float PlayerDamage;

        [Header("Should be between 8-10")]
        public float DashSpeed;

        [Header("Can be 100")]
        public int PlayerHealth;
    }
}


