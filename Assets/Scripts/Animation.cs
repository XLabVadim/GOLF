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
        public void _Idle()
        {
            anim.SetBool("Idle",false);
        }
        public void _Push()
        {
            anim.SetBool("Zamah", false);
        }
        public void push()
        {
            anim.SetBool("Zamah", true);
        }
        public void _Udar()
        {
            anim.SetBool("Udar", true);
        }
        public void Udar()
        {
            anim.SetBool("Udar", false);
        }
    }
}

