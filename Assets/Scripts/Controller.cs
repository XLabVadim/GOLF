using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private StoneSpawn _stone;
    [SerializeField]
    private MoveStone _moveStone;
    [SerializeField]
    private Animator anim;
    private bool m_Idle;
    private bool b_Push;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (_stone)
            {
                _stone.Spawn();
            }
        }
        if (_stone)
        {
            _moveStone.Fly();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Idle",true);
        }else anim.SetBool("Idle", false);

    }
}
