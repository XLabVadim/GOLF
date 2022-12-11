using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
public class MenuUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuPlayer;
    bool isMenu = false;
    private Camera cameraMenu;
    [SerializeField]
    Camera cameraPlayer;

    private void Start()
    {
        menu.SetActive(true);
        menuPlayer.SetActive(false);
        cameraMenu = GetComponent<Camera>();
        cameraMenu = Camera.main;
    }


    public void ActiveMenu()
    {
        if (isMenu)
        {
            menu.SetActive(true);
            menuPlayer.SetActive(false);
        }
        else
        {
            cameraMenu.enabled = !cameraMenu.enabled;
            cameraPlayer.enabled = !cameraPlayer.enabled;
            menu.SetActive(false);
            menuPlayer.SetActive(true);
            
        }
    }

}
}
