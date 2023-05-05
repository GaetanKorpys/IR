using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGenerator : MonoBehaviour
{
    public GameObject lightObject;
    private Behaviour light;

    void Start()
    {
        // Récupère la position du centre de l'objet
        Vector3 center = GetComponent<Renderer>().bounds.center;

        // Déplace le haloObject à la position du centre de l'objet
        lightObject.transform.position = center;

        // Récupère le composant Behaviour "Halo" attaché à l'objet
        light = lightObject.GetComponent<Behaviour>();

        // Désactive le Halo
        light.enabled = false;
    }

    void OnMouseDown()
    {
        light.enabled = true;
    }

    void OnMouseUp()
    {
        light.enabled = false;
    }
}
