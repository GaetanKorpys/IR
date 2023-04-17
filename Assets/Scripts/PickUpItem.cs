using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;

    public PickUpBehaviour playerPickUpBehaviour;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if (hit.transform.CompareTag("Item"))
            {
                Debug.Log("Item in front");


                if(Input.GetKeyDown(KeyCode.E))
                {
                    playerPickUpBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
    }
}
