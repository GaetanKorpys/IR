using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private GameObject pickupText;

    public PickUpBehaviour playerPickUpBehaviour;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, layerMask))
        {
            if (hit.transform.CompareTag("Item"))
            {
                
                pickupText.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    playerPickUpBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
        else
            pickupText.SetActive(false);
    }
}
