using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    public List<GameObject> objectsToGenerate;
    public GameObject generatedObject;
    public bool test;
    private int randomIndex;

    void Start()
    {
        Bounds bounds = GetComponent<Renderer>().bounds;
        Vector3 objectPosition = bounds.center;
        randomIndex = Random.Range(0, objectsToGenerate.Count);
        generatedObject = Instantiate(objectsToGenerate[randomIndex], objectPosition, transform.rotation);
        generatedObject.transform.Rotate(-88, 59, -93);

        Vector3 offset = generatedObject.transform.position - generatedObject.GetComponent<Renderer>().bounds.center;
        generatedObject.transform.position = objectPosition + offset;
        test = false;
    }

    void Update(){
        if(test){
            Destroy(generatedObject);
            objectsToGenerate.Remove(objectsToGenerate[randomIndex]);
            Bounds bounds = GetComponent<Renderer>().bounds;
            Vector3 objectPosition = bounds.center;
            randomIndex = Random.Range(0, objectsToGenerate.Count);
            generatedObject = Instantiate(objectsToGenerate[randomIndex], objectPosition, transform.rotation);
            generatedObject.transform.Rotate(-88, 59, -93);

            Vector3 offset = generatedObject.transform.position - generatedObject.GetComponent<Renderer>().bounds.center;
            generatedObject.transform.position = objectPosition + offset;
            test = false;
            }
    }
}

