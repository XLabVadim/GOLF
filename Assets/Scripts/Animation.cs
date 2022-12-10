using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Animation : MonoBehaviour
    {
        [SerializeField]
        private Animator anim;

        public void Idle()
        {
            anim.SetBool("Idle",true);
        }
        public void _Push()
        {
            anim.SetBool("Idle", false);
        }
    }
}

