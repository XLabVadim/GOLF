using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStone : MonoBehaviour
{
    public Transform target;
    public float speed_move;
    public float speed_run;
    public float speed_rotate;

    public void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Finish").transform;
    }
    public void Fly()
    {
        target = GameObject.FindGameObjectWithTag("Finish").transform;
        gameObject.transform.Translate(Vector3.up * speed_run * Time.deltaTime);
        Vector3 target_vector = target.transform.position - gameObject.transform.position;
        gameObject.transform.up = Vector3.Slerp(gameObject.transform.up, target_vector, speed_rotate * Time.deltaTime);
    }
}
