using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        [SerializeField]
        private float m_power = 100f;
        Vector3 vec = new Vector3(-10, 10, 1);
        public int Score = 0;
        public Text Scoretext;

        [SerializeField]
        private MenuUI StartPlay;

        private List<GameObject> m_stones = new();

        void Update()
        {
            //Debug.Log(StartPlay.ExitMenu);
            if (StartPlay.ExitMenu == true)
            {
                m_timer += Time.deltaTime;
            }
            if (m_timer >= m_delay && StartPlay.ExitMenu == true)
            {
                var u_stone = _stone.Spawn();
                m_stones.Add(u_stone);
                m_timer -= m_delay;
            }

            Scoretext.text = Score.ToString();
        }

        public void Up()
        {
            anim.push();
            anim.Udar();
        }

        public void Down()
        {
            anim._Push();
            anim._Udar(); 
            anim.Idle();
        }

        public void OnCollisionStone(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Stone>(out var stone))
            {
                stone.SetAffect(false);
                //var contact = collision.contacts[0];
                var contact = collision.GetContact(0);
                var stick = contact.thisCollider.GetComponent<CollisionPlow>();
                var body = contact.otherCollider.GetComponent<Rigidbody>();
                body.AddForce(stick.dir * m_power, ForceMode.Impulse);
                Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
                Score += 1;
            }
        }
        private void ClearStones()
		{
            Debug.Log("gggggg");
			foreach (GameObject u_stone in m_stones)
			{
				Destroy(u_stone);
			}
			m_stones.Clear();
		}

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            GameEvent.onGameOver += OnGameOver;
        }

        private void OnGameOver()
        {

            GameEvent.onGameOver -= OnGameOver;
            Debug.Log("Game Over");
            StartPlay.ExitMenu = false;
            StartPlay.DownMenu();
            ClearStones();
        }

        private void OnDestroy()
        {
            GameEvent.onGameOver -= OnGameOver;
        }
    }
}
