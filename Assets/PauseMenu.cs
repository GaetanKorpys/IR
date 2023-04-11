using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isMenuOpened = false;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField]
    private ThirdPersonOrbitCamBasic cameraScript;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpened = !isMenuOpened;

            pauseMenu.SetActive(isMenuOpened);
            optionsMenu.SetActive(false);

            Time.timeScale = isMenuOpened ? 0 : 1;
            cameraScript.enabled = !isMenuOpened;
        }
    }
}
