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

        void Update()
        {
            //Debug.Log(StartPlay.ExitMenu);
            if (StartPlay.ExitMenu == true)
            {
                m_timer += Time.deltaTime;
            }
            if (m_timer >= m_delay && StartPlay.ExitMenu == true)
            {
                _stone.Spawn();
                m_timer -= m_delay;
            }

            Scoretext.text = Score.ToString();
        }

        public void Up()
        {
            anim._Push();
            anim._Udar();
            anim._Idle();
            //Debug.Log("Space key was released.");
        }

        public void Down()
        {
            anim.push();
            anim.Idle();
            anim.Udar();
            //Debug.Log("Space key was pressed.");
        }

        public void OnCollisionStone(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Stone>(out var stone))
            {
                stone.SetAffect(false);
                //var contact = collision.contacts[0];
                var contact = collision.GetContact(0);
                var body = contact.otherCollider.GetComponent<Rigidbody>();
                if (contact.normal != null)
                {
                    body.AddForce(vec * m_power, ForceMode.Impulse);
                }
                Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
                Score += 1;
            }
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            GameEvent.onGameOver += OnGameOver;
        }

        private void OnGameOver()
        {
            GameEvent.onGameOver -= OnGameOver;
            Debug.Log("Game Over");
            StartPlay.ExitMenu = false;
            StartPlay.DownMenu();
        }

        private void OnDestroy()
        {
            GameEvent.onGameOver -= OnGameOver;
        }
    }
}
