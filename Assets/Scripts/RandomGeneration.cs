using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    public List<GameObject> objectsToGenerate;
    public GameObject generatedObject;

    void Start()
    {
        Bounds bounds = GetComponent<Renderer>().bounds;
        Vector3 objectPosition = bounds.center;
        int randomIndex = Random.Range(0, objectsToGenerate.Count);
        generatedObject = Instantiate(objectsToGenerate[randomIndex], objectPosition, transform.rotation);

        Vector3 offset = generatedObject.transform.position - generatedObject.GetComponent<Renderer>().bounds.center;
        generatedObject.transform.position = objectPosition + offset;
    }
}
