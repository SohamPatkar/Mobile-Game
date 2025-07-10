using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileController.Enemy
{
    [CreateAssetMenu(menuName = "EnemySO")]
    public class EnemySO : ScriptableObject
    {
        public string Name;
        public Vector3 SpawnPoint;
    }
}

