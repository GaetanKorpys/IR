using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIncisor : MonoBehaviour
{
    public Light lightComponent;

    void Update()
    {    
        GameObject generatedObject = GameObject.Find("Incisor_lower_left_1(Clone)");
        if (generatedObject != null)
        {
            lightComponent.color = Color.green;
        } else {
            Debug.Log("Not found");
        }
    }
}
