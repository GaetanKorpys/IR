using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public GameObject objectToCheck;
    //public GameObject objectPosition;
    public Vector3 desiredPosition;
    public GameObject halo;

    void Update()
    {
        //desiredPosition = objectPosition.transform.position;
        Behaviour haloComponent = (Behaviour)halo.GetComponent<Halo>();
       
        if (objectToCheck.transform.position == desiredPosition)
        {
            haloComponent.enabled = true;
        } else {
            haloComponent.enabled = false;
        }  
    }
}
