using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : MonoBehaviour
{
    public GameObject haloObject;
    private Behaviour halo;

    void Start()
    {
        // Récupère la position du centre de l'objet
        Vector3 center = GetComponent<Renderer>().bounds.center;

        // Déplace le haloObject à la position du centre de l'objet
        haloObject.transform.position = center;

        // Récupère le composant Behaviour "Halo" attaché à l'objet
        halo = haloObject.GetComponent<Behaviour>();

        // Désactive le Halo
        halo.enabled = false;
    }

    void OnMouseDown()
    {
        halo.enabled = true;
    }

    void OnMouseUp()
    {
        halo.enabled = false;
    }
}
