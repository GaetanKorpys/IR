using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanine : MonoBehaviour
{
    public Light lightComponent;

    void Update()
    {
        GameObject generatedObject = GameObject.Find("Canine_lower_left(Clone)");
        if (generatedObject != null)
        {
            lightComponent.color = Color.green;
        }
    }
}
