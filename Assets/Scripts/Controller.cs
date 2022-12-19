using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Controller : MonoBehaviour
    {
        

        [SerializeField]
        private Stone stone;

        [SerializeField]
        private Animation anim;
        
        [SerializeField]
        private float m_power = 100f;

        [SerializeField]
        private MenuUI StartPlay;


        public void Up()
        {
            anim._Push();
            anim._Udar(); 
        }

        public void Down()
        {
            anim.push();
            anim.Udar();
            
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
                StartPlay.Score += 1;
            }
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
            StartPlay.ClearStones();
        }

        private void OnDestroy()
        {
            GameEvent.onGameOver -= OnGameOver;
        }
    }
}
