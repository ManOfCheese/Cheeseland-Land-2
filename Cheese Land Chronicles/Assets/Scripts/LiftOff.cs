using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOff : MonoBehaviour {

    public float rotateSpeed;
    private float liftOffSpeed;
    public float rotateSpeedMultiplier;
    private int timer;

    private void Start()
    {
        timer = Random.Range(10, 500);
    }

    // Update is called once per frame
    void Update ()
    {
        timer -= 1;
        if (timer <= 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotateSpeed, transform.eulerAngles.z);
            if (rotateSpeed <= 50)
            {
                liftOffSpeed = rotateSpeed * 0.2f;
                rotateSpeed *= rotateSpeedMultiplier;
            }
            if (rotateSpeed >= 20 && rotateSpeed <= 50)
            {
                transform.position += Vector3.up * Time.deltaTime * liftOffSpeed;
            }
        }
	}
}
