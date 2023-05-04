using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIncisor : MonoBehaviour
{
    public Light lightComponent;
    public AudioClip soundClipGoodAnswer;
    public AudioClip soundClipBadAnwser;
    public GameObject gameObject;

    private AudioSource audioSource;
    private bool  testGoodAnswer = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClipBadAnwser;
    }

    void Update()
    {    
        GameObject generatedObject = GameObject.Find("UpperJaw.001 (2)(Clone)");
        if (generatedObject != null)
        {
            lightComponent.color = Color.green;
            audioSource.clip = soundClipGoodAnswer;
            testGoodAnswer = true;
        } else {
            lightComponent.color = Color.red;
            audioSource.clip = soundClipBadAnwser;
            testGoodAnswer = false;
        }
    }

     void OnMouseDown()
    {
        audioSource.Play();

        if(testGoodAnswer){
            gameObject.GetComponent<RandomGeneration>().test = true;
        }
    }
}
