using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField]
        private StoneSpawn _stone;
        [SerializeField]
        private HealthBar Health;
        [SerializeField]
        private Dragon drag;
        public GameObject menu;
        public GameObject menuPlayer;
        public bool ExitMenu = false;
        private Camera cameraMenu;
        [SerializeField]
        Camera cameraPlayer;
        [SerializeField]
        public SpawnDragon _DragonSpawnPoint;
        [SerializeField]
        Controller cont;
        [SerializeField]
        private GameSettings mui_settings;
        private float m_maxDelay = 0f;
        private float m_delay = 0f;
        private float m_minDela = 0f;
        private float Step = 0f;
        private float m_timer = 0f;
        public int Score = 0;
        public Text Scoretext;
        private List<GameObject> m_stones = new();
        private void Start()
        {
            menu.SetActive(true);
            menuPlayer.SetActive(false);
            cameraMenu = GetComponent<Camera>();
            cameraMenu = Camera.main;
            
        }

        public float Calc()
        {
            return Random.Range(mui_settings.minDelay, m_maxDelay);
        }

        public void ActiveMenu()
        {
            m_minDela = mui_settings.minDelay;
            m_delay = Calc();
            Step = mui_settings.stepDealay;
            m_maxDelay = mui_settings.maxDelay;
            Score = 0;
            drag.Fly = false;
            Health._HealthBarFilling.fillAmount = 100;
            drag._currentHealth = drag._maxHealth;
            cameraMenu.enabled = !cameraMenu.enabled;
            cameraPlayer.enabled = !cameraPlayer.enabled;
            menu.SetActive(false);
            menuPlayer.SetActive(true);
            ExitMenu = true;
        }
        public void DownMenu()
        {
            Debug.Log(drag._currentHealth);
            /*if (drag._currentHealth <= 0)
            {
                _DragonSpawnPoint.PointSpawnDragon();
            }*/
            drag.Fly = false;
            cont.StartGame();
            cameraMenu.enabled = !cameraMenu.enabled;
            cameraPlayer.enabled = !cameraPlayer.enabled;
            menu.SetActive(true);
            menuPlayer.SetActive(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        void Update()
        {
            //Debug.Log(StartPlay.ExitMenu);
            if (ExitMenu == true)
            {
                m_timer += Time.deltaTime;
            }
            if (m_timer >= m_delay && ExitMenu == true)
            {
                var u_stone = _stone.Spawn();
                m_stones.Add(u_stone);
                m_timer -= m_delay;

                m_delay = Calc();
                while (m_maxDelay > m_minDela)
                {
                    m_maxDelay -= Step;
                    break;
                }
            }

            Scoretext.text = Score.ToString();
        }
        public void ClearStones()
        {
            //Debug.Log("gggggg");
            foreach (GameObject u_stone in m_stones)
            {
                Destroy(u_stone);
            }
            m_stones.Clear();
        }

    }
}
