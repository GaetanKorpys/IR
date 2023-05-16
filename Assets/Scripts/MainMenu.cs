using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private Slider soundSlider;

    [SerializeField]
    private GameObject optionsPanel;

    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField] 
    private GameObject chaptersPanel;

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

        for(int i = 0; i < qualities.Length; i++)
        {
            qualityOptions.Add(qualities[i]);

            if(i == QualitySettings.GetQualityLevel())
                currentQualityIndex = i;
        }

        qualitiesDropdown.AddOptions(qualityOptions);
        qualitiesDropdown.value = currentQualityIndex;
        qualitiesDropdown.RefreshShownValue();

    }

    public void NewGameButton()
    {
        SceneManager.LoadScene("DecouverteDesDents");
    }

    public void QuiteButton()
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
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void BackButton()
    {
        optionsPanel.SetActive(false);
        chaptersPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ChaptersButton()
    {
        mainMenuPanel.SetActive(false);
        chaptersPanel.SetActive(true);
    }

    public void GameButton()
    {
        SceneManager.LoadScene("DecouverteDesDents");
    }

    public void Game2Button()
    {
        SceneManager.LoadScene("TraumatismeDentaire");
    }

    public void setQualityGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
