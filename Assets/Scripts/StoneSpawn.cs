using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
public class StoneSpawn : MonoBehaviour
{
    public GameObject _stone;
    public GameObject Spawn()
    {
        var position = transform.position;
        var rotation = transform.rotation;
        
        return GameObject.Instantiate(_stone, position, rotation);
    }
    
}
}
