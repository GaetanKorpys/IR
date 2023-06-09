using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isPause = true;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject pauseOptions;

    [SerializeField]
    private GameObject regleMenu;

    [SerializeField]
    private GameObject explicationMenu;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private ThirdPersonOrbitCamBasic cameraScript;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private Slider soundSlider;

    [SerializeField]
    private Dropdown qualitiesDropdown;

    [SerializeField]
    private GameObject inventoryPanel;

    [SerializeField]
    private GameObject timerPanel;

    [SerializeField]
    private GameObject inventory;

    [SerializeField]
    private GameObject victoryPanel;

    [SerializeField]
    private GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        //Initialisation du slider de volume
        audioMixer.GetFloat("Volume", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        //Initialisation de la qualit� graphique
        string[] qualities = QualitySettings.names;
        qualitiesDropdown.ClearOptions();

        List<string> qualityOptions = new List<string>();
        int currentQualityIndex = 0;

        for (int i = 0; i < qualities.Length; i++)
        {
            qualityOptions.Add(qualities[i]);

            if (i == QualitySettings.GetQualityLevel())
                currentQualityIndex = i;
        }

        qualitiesDropdown.AddOptions(qualityOptions);
        qualitiesDropdown.value = currentQualityIndex;
        qualitiesDropdown.RefreshShownValue();

        Time.timeScale = isPause ? 0 : 1;
        cameraScript.enabled = !isPause;

    }


    // Update is called once per frame
    void Update()
    {

        if(Timer.instance != null && Timer.instance.end)
        {
            if (Inventory.instance.isGameVictory())
                victoryPanel.SetActive(true);
            else
                gameOverPanel.SetActive(true);

            Time.timeScale=0;
            cameraScript.enabled = false;
        }

        else if(Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;

            pauseMenu.SetActive(isPause);
            pausePanel.SetActive(isPause);
            inventoryPanel.SetActive(false);

            timerPanel.SetActive(!isPause);

            pauseOptions.SetActive(false);

            Time.timeScale = isPause ? 0 : 1;
            cameraScript.enabled = !isPause;
        }
    }

    public void RestartGameButton()
    {
        pausePanel.SetActive(false);
        pauseMenu.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        cameraScript.enabled = true;
        timerPanel.SetActive(true);
    }

    public void GoToExplication()
    {
        regleMenu.SetActive(false);
        explicationMenu.SetActive(true);
    }

    public void BackToMenuButton()
    {
        pausePanel.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        cameraScript.enabled = true;

        SceneManager.LoadScene("MainMenu");
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinueButton()
    {
        pausePanel.SetActive(false);
        explicationMenu.SetActive(false);
        Time.timeScale = 1;
        cameraScript.enabled = true;
        timerPanel.SetActive(true);

        inventory.SetActive(true);

    }

    public void BackButton()
    {
        pauseOptions.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void EnableDisableOptionsPanel()
    {
        pauseMenu.SetActive(false);
        pauseOptions.SetActive(true);
    }


    public void setQualityGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
