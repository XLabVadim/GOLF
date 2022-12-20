using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
public class SpawnDragon : MonoBehaviour
{
    public GameObject DragonSpawn;

    public void PointSpawnDragon()
    {
        var position = transform.position;
        var rotation = transform.rotation;
        Instantiate(DragonSpawn, position, rotation);
    }
}
}

