using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isMenuOpened = false;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject pauseOptions;

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

    // Start is called before the first frame update
    void Start()
    {
        //Initialisation du slider de volume
        audioMixer.GetFloat("Volume", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        //Initialisation de la qualité graphique
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

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpened = !isMenuOpened;

            pauseMenu.SetActive(isMenuOpened);
            pausePanel.SetActive(isMenuOpened);

            pauseOptions.SetActive(false);

            Time.timeScale = isMenuOpened ? 0 : 1;
            cameraScript.enabled = !isMenuOpened;
        }
    }

    public void RestartGameButton()
    {
        pausePanel.SetActive(false);
        pauseMenu.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        cameraScript.enabled = true;
    }

    public void BackToMenuButton()
    {
        pausePanel.SetActive(false);
        pauseMenu.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        cameraScript.enabled = true;

        SceneManager.LoadScene("MainMenu");
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
