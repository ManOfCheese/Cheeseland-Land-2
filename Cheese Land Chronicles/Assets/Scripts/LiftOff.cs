using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOff : MonoBehaviour {
    //Variables for controllin initial lift off.
    public float rotateSpeed; //Sets the base rotate speed of the object. This value increases over time by the amount specified in the rotateSpeedMultiplier.
    public float rotateSpeedModifier; //Determines by what factor the rotateSpeed increases per frame.
    private float liftOffSpeed; //Sets the speed at which the object lifts off from the ground. Is determined by the rotatespeed.
    public float liftOffSpeedModifier; //Determines what percentage of the rotateSpeed constitutes the liftOffSpeed.

    //Variables for controlling the minimum and maximum rotate speeds.
    public int minRotateSpeed; //Determines the minimum rotateSpeed required for lift off.
    public int maxRotateSpeed; //Determines the maximum rotateSpeed that can be reached.

    //Variables for controlling the target and speed of the attack.
    public Transform target; //Deternines the target of the objects horizontal flight.
    public float speed; //Determines the speed of the objects horizontal flight.

    //Variables for controlling how high the object will fly
    public float maxHeight; //Sets the maximum height the object will lift off the ground compared to its starting height.
    private float heightIncrease = 0;

    //Variables for controlling the delay timer.
    public int timerMin; //Minimum amount for the timer.
    public int timerMax; //Maximum amount for the timer.
    private int timer; //A timer to randomize when the object starts lifting off.

    private void Start()
    {
        timer = Random.Range(timerMin, timerMax); //Set the timer to a random number between 10 and 500.
    }

    void Update ()
    {
        //Lifting off
        timer -= 1; //Subracts 1 from the timer varaible each frame.
        if (timer <= 0) //If the time raches zero
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotateSpeed, transform.eulerAngles.z); //Start rotating in the y direction by an amount of degrees specified by the rotateSpeed variable
            if (rotateSpeed <= maxRotateSpeed) //If the rotate speed is below 50 
            {
                liftOffSpeed = rotateSpeed * liftOffSpeedModifier; //set the liftoff speed to the rotateSpeed * the liftOffSpeedModifier.
                rotateSpeed *= rotateSpeedModifier; //multiply the rotateSpeed by the rotateSpeedModifier.
            }
            if (rotateSpeed >= minRotateSpeed && heightIncrease <= maxHeight) //If the rotateSpeed is above the minRotateSpeed and the current x position is below the starting x value + the max x value.
            {
                transform.position += Vector3.up * Time.deltaTime * liftOffSpeed; //Move the object up by the value of liftOffSpeed each frame.
                heightIncrease += Time.deltaTime * liftOffSpeed; //Update the height increase so we know how far we have moved on the y axis.
            }
        }

        //Flying towards a target
        float step = speed * Time.deltaTime; //determines the steps in which the Vector3.moveTowards moves towards it's target.

        if (heightIncrease >= maxHeight) //if the rotateSpeed is at or above its maximum
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step); //Move towards the target
            if (transform.position == target.position) //If the target is reached
            {
                Destroy(this.gameObject); //DIE
            }
        }
	}
}
