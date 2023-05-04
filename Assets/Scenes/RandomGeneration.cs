using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    public List<GameObject> objectsToGenerate;
    public GameObject generatedObject;
    public bool test;

    void Start()
    {
        Bounds bounds = GetComponent<Renderer>().bounds;
        Vector3 objectPosition = bounds.center;
        int randomIndex = Random.Range(0, objectsToGenerate.Count);
        generatedObject = Instantiate(objectsToGenerate[randomIndex], objectPosition, transform.rotation);
        generatedObject.transform.Rotate(-88, 59, -93);

        Vector3 offset = generatedObject.transform.position - generatedObject.GetComponent<Renderer>().bounds.center;
        generatedObject.transform.position = objectPosition + offset;
        test = false;
    }

    void Update(){
        if(test){
            Destroy(generatedObject);
            Bounds bounds = GetComponent<Renderer>().bounds;
            Vector3 objectPosition = bounds.center;
            int randomIndex = Random.Range(0, objectsToGenerate.Count);
            generatedObject = Instantiate(objectsToGenerate[randomIndex], objectPosition, transform.rotation);
            generatedObject.transform.Rotate(-88, 59, -93);

            Vector3 offset = generatedObject.transform.position - generatedObject.GetComponent<Renderer>().bounds.center;
            generatedObject.transform.position = objectPosition + offset;
            test = false;
            }
    }
}

