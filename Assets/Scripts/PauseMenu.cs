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
    private GameObject panelPause;

    [SerializeField]
    private ThirdPersonOrbitCamBasic cameraScript;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpened = !isMenuOpened;

            pauseMenu.SetActive(isMenuOpened);
            panelPause.SetActive(isMenuOpened);

            optionsMenu.SetActive(false);

            Time.timeScale = isMenuOpened ? 0 : 1;
            cameraScript.enabled = !isMenuOpened;
        }
    }

    public void RestartGameButton()
    {
        panelPause.SetActive(false);
        pauseMenu.SetActive(false);
        panelPause.SetActive(false);
        Time.timeScale = 1;
        cameraScript.enabled = true;
    }

}
