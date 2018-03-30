using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarActivate : MonoBehaviour {

    private GameObject objectOnAltar;
    public GameObject door;
    public PlayerItemSearch playerItemSearch;
    public bool doorOn = false;
    public string keyTag;

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == keyTag)
        {
            if (playerItemSearch.objectInHand != null)
            {
                playerItemSearch.DropItem();
                ((Rigidbody)other.GetComponent(typeof(Rigidbody))).isKinematic = true;
                other.transform.position = transform.position + new Vector3(0, 2, 0);
                other.gameObject.layer = 0;
                if (doorOn == true)
                {
                    door.SetActive(true);
                }
                else if (doorOn == false)
                {
                    door.SetActive(false);
                }
            }
            else if (playerItemSearch.objectInHand == null)
            {
                ((Rigidbody)other.GetComponent(typeof(Rigidbody))).isKinematic = true;
                other.transform.position = transform.position + new Vector3(0, 2, 0);
                other.gameObject.layer = 0;
                if (doorOn == true)
                {
                    door.SetActive(true);
                }
                else if (doorOn == false)
                {
                    door.SetActive(false);
                }
            }
        }
    }
}
