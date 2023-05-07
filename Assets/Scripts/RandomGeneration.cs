using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    public List<GameObject> objectsToGenerate;
    public GameObject generatedObject;
    public bool answer;
    private int randomIndex;

    void generateTooth(){
        Bounds bounds = GetComponent<Renderer>().bounds;
        Vector3 objectPosition = bounds.center;
        //Séléction et génération d'unde dent au hasard
        randomIndex = Random.Range(0, objectsToGenerate.Count);
        generatedObject = Instantiate(objectsToGenerate[randomIndex], objectPosition, transform.rotation);
        generatedObject.transform.Rotate(-88, 59, -93);
        
        //On centre la dent à gauche
        Vector3 offset = generatedObject.transform.position - generatedObject.GetComponent<Renderer>().bounds.center;
        generatedObject.transform.position = objectPosition + offset;
        //La variable "answer" sert à verifier si le joueur a cliqué sur la bonne dent
        answer = false;
    }

    void Start()
    {
       generateTooth();
    }

    void Update(){
        if(answer){
            //Si le joueur a juste on supprime cette dent et on en génère une autre
            Destroy(generatedObject);
            objectsToGenerate.Remove(objectsToGenerate[randomIndex]);
            generateTooth();
        }
    }
}

