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

    private void Start()
    {
        menu.SetActive(true);
        menuPlayer.SetActive(false);
        cameraMenu = GetComponent<Camera>();
        cameraMenu = Camera.main;
    }


    public void ActiveMenu()
    {
        cont.Score = 0;
        cameraMenu.enabled = !cameraMenu.enabled;
        cameraPlayer.enabled = !cameraPlayer.enabled;
        menu.SetActive(false);
        menuPlayer.SetActive(true);
        ExitMenu = true;
    }
    public void DownMenu()
    {
        cameraMenu.enabled = !cameraMenu.enabled;
        cameraPlayer.enabled = !cameraPlayer.enabled;
        menu.SetActive(true);
        menuPlayer.SetActive(false);
    }

}
}
