using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
public class AnimationDragon : MonoBehaviour
{
    [SerializeField]
    private Animator dragonAnim;

    public void true_FlyAnim()
    {
        dragonAnim.SetBool("FlyAnim", true);
    }

    public void false_FlyAnim()
    {
        dragonAnim.SetBool("FlyAnim", false);
    }
}
}

