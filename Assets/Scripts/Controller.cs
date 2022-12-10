using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
public class Controller : MonoBehaviour
{
    [SerializeField]
    private StoneSpawn _stone;
    [SerializeField]
    private Stone stone;
    [SerializeField]
    private Animation anim;
	private float m_timer = 0f;
    private bool m_Idle;
    private bool b_Push;
    [SerializeField]
	private float m_delay = 1f;
	[SerializeField] private float m_power = 100f;
    Vector3 vec = new Vector3(-10,10,1);

    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_delay)
        {
            _stone.Spawn();
            m_timer -= m_delay;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.Idle();
        }else anim._Push();

    }
    public void OnCollisionStone(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<Stone>(out var stone))
			{
				//stone.SetAffect(false);
				//var contact = collision.contacts[0];
				var contact = collision.GetContact(0);
				var body = contact.otherCollider.GetComponent<Rigidbody>();
				if (contact.normal != null)
				{
					body.AddForce(vec * m_power, ForceMode.Impulse);
				}
				//Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
			}
		}
}
}
