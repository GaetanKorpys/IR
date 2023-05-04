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
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Incisor");
        if (gameObjects.Length != 0)
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

        if(testGoodAnswer && GetComponent<Renderer>().enabled == false){
            gameObject.GetComponent<RandomGeneration>().test = true;
            GetComponent<Renderer>().enabled = true;
        }
    }
}
