using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int HP = 100;
    private void OnCollisionEnter(Collision stoneother)
    {
        HP -= 1;
    }
}
