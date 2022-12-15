using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
public class MenuUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuPlayer;
    public bool ExitMenu = false;
    private Camera cameraMenu;
    [SerializeField]
    Camera cameraPlayer;
    [SerializeField]
    Controller cont;
    [SerializeField]
    private GameSettings mui_settings;
    public float m_maxDelay = 0f;
    public float m_delay = 0f;
    public float m_minDela = 0f;
    public float Step = 0f;
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
        cont.Score = 0;
        cameraMenu.enabled = !cameraMenu.enabled;
        cameraPlayer.enabled = !cameraPlayer.enabled;
        menu.SetActive(false);
        menuPlayer.SetActive(true);
        ExitMenu = true;
    }
    public void DownMenu()
    {
        cont.StartGame();
        
        cameraMenu.enabled = !cameraMenu.enabled;
        cameraPlayer.enabled = !cameraPlayer.enabled;
        menu.SetActive(true);
        menuPlayer.SetActive(false);
    }

}
}
