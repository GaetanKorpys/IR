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
    private GameObject Inventory;

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

        Time.timeScale = isPause ? 0 : 1;
        cameraScript.enabled = !isPause;

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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

    public void BackToMenuButton()
    {
        pausePanel.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        cameraScript.enabled = true;

        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueButton()
    {
        pausePanel.SetActive(false);
        regleMenu.SetActive(false);
        Time.timeScale = 1;
        cameraScript.enabled = true;
        timerPanel.SetActive(true);

        Inventory.SetActive(true);

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
