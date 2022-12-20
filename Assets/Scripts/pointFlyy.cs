using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class pointFlyy : MonoBehaviour
    {
        public Transform point;
        public Transform pointSpawn;
        [SerializeField]
        private Dragon dragonfly;
        private float speed = 5f;
        private float SpeedSpawn = 100f;

        private void Update()
        {
            if (dragonfly.Fly)
            {
                dragonfly.transform.position = Vector3.MoveTowards(dragonfly.transform.position, point.position ,speed * Time.deltaTime);
            }
            else 
            {
                dragonfly.transform.position = Vector3.MoveTowards(dragonfly.transform.position, pointSpawn.position ,SpeedSpawn * Time.deltaTime);
            }
        }
    }
}

