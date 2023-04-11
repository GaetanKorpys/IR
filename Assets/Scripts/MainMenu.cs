using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        //Initialisation du slider de volume
        audioMixer.GetFloat("Volume", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene("Chapeau");
    }

    public void NewQuiteButton()
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
        mainMenuPanel.SetActive(true);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
