using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemSearch : MonoBehaviour {

    public GameObject objectInHand;
    private Rigidbody objectRigidbody;
    public int throwSpeed;

    private bool leftMouseClicked;
    private bool rightMouseClicked;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            LayerMask layerMask = LayerMask.GetMask("PickUpItems");
            RaycastHit hit;
                
            if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hit, 3.0f, layerMask) && objectInHand == null)
            {
                objectInHand = hit.collider.gameObject;
                objectRigidbody = ((Rigidbody)objectInHand.GetComponent(typeof(Rigidbody)));
                objectRigidbody.isKinematic = true;
                objectInHand.transform.parent = transform;
            }
            else if (objectInHand != null)
            {
                DropItem();
            }
        }

        if (Input.GetMouseButtonDown(0) && objectInHand != null)
        {
            objectRigidbody.isKinematic = false;
            objectRigidbody.AddForce(transform.forward * throwSpeed);
            objectInHand.transform.parent = null;
            objectInHand = null;
        }
    }

    public void DropItem()
    {
        objectRigidbody.isKinematic = false;
        objectInHand.transform.parent = null;
        objectInHand = null;
    }
}
