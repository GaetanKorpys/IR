using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanine : MonoBehaviour
{
    public Light lightComponent;
    public AudioClip soundClipGoodAnswer;
    public AudioClip soundClipBadAnwser;
    public GameObject randomTooth;

    private AudioSource audioSource;
    private bool testGoodAnswer = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        //On récupère tous les objets qui sont tagués avec le tag "Canine"
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Canine");
        //Si un objet canine existe, c'est que la dent à gauche est une canine
        if (gameObjects.Length != 0)
        {
            //On change la couleur de la lumière de la dent, sa source audio et on indique que la dent à gauche lui correspond
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

        //On vérifie si la dent de gauche correspond. Si c'est le cas on modifie la variable "answer" de randomTooth 
        if(testGoodAnswer && GetComponent<Renderer>().enabled == false){
            randomTooth.GetComponent<RandomGeneration>().answer = true;
            GetComponent<Renderer>().enabled = true;
        }
    }
}
