using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeDuration;

    private float timer;

    private float flashTimer;
    private float flashDuration = 1f;

    [SerializeField]
    private bool countdown = true;



    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI separator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    public static Timer instance;

    public bool end = false;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown && timer > 0)
        {
            if(timer < 30)  
                Flash(); 
            else
            {
                timer -= Time.deltaTime;
                UpdateTimerDisplay(timer);
            }

        }
        else
        {

            firstMinute.text = "";
            secondMinute.text = "";
            separator.text = "";
            firstSecond.text = "";
            secondSecond.text = "";
            
            end = true;
            
        }
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void Flash()
    {
        if (countdown && timer != 0)
        {
            //timer = 0;
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }

        if (!countdown && timer != timeDuration)
        {
            //timer = 0;
            UpdateTimerDisplay(timer);
        }

        if (flashTimer <= 0)
            flashTimer = flashDuration;

        else if (flashTimer >= flashDuration / 2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void ResetTimer()
    {
        if(countdown)
            timer = timeDuration;
        else
            timer = 0;
        SetTextDisplay(true);
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;

    }
}
