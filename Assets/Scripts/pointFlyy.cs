using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class pointFlyy : MonoBehaviour
    {
        public Transform point;
        [SerializeField]
        private Dragon dragonfly;
        private float speed = 5f;

        private void Update()
        {
            if (dragonfly.Fly)
            {
                dragonfly.transform.position = Vector3.MoveTowards(dragonfly.transform.position, point.position ,speed * Time.deltaTime);
            }
        }
    }
}

