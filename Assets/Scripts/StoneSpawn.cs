using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{
    public GameObject stone;
    /*public Transform target;
    public float speed_move;
    public float speed_run;
    public float speed_rotate;*/

    public void Spawn()
    {
        var position = transform.position;
        var rotation = transform.rotation;
        GameObject.Instantiate(stone, position, rotation);
    }
    /*public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Finish").transform;
    }
    void Update()
    {
        GameObject.transform.Translate(Vector3.up * speed_run * Time.deltaTime);
        Vector3 target_vector = target.transform.position - gameObject.transform.position;
        GameObject.transform.up = Vector3.Slerp(gameObject.transform.up, target_vector, speed_rotate * Time.deltaTime);
    }*/
    
}
