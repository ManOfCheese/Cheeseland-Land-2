using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject BulletPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position + transform.forward, Quaternion.identity);
            Rigidbody bulletRigidbody = (Rigidbody)bullet.GetComponent(typeof(Rigidbody));

            bulletRigidbody.AddForce(transform.forward * 1000, ForceMode.Force);
        }

        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hitInfo))
            {
                if(hitInfo.collider.gameObject.tag == "Enemy")
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }
}
