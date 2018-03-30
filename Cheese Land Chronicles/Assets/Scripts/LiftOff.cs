﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOff : Enemy {
    //Variables for controllin initial lift off.
    public float rotateSpeed = 0.5f; //Sets the base rotate speed of the object. This value increases over time by the amount specified in the rotateSpeedMultiplier.
    public float rotateSpeedModifier = 1.05f; //Determines by what factor the rotateSpeed increases per frame.
    private float liftOffSpeed; //Sets the speed at which the object lifts off from the ground. Is determined by the rotatespeed.
    public float liftOffSpeedModifier = .5f; //Determines what percentage of the rotateSpeed constitutes the liftOffSpeed.

    //Variables for controlling the minimum and maximum rotate speeds.
    public int minRotateSpeed = 10; //Determines the minimum rotateSpeed required for lift off.
    public int maxRotateSpeed = 30; //Determines the maximum rotateSpeed that can be reached.

    //Variables for controlling the target and speed of the attack.
    public Transform target; //Deternines the target of the objects horizontal flight.
    public float speed = 70f; //Determines the speed of the objects horizontal flight.

    //Variables for controlling how high the object will fly
    public float maxHeight = 20f; //Sets the maximum height the object will lift off the ground compared to its starting height.
    private float heightIncrease = 0;

    //Variables for controlling the delay timer.
    public int timerMin = 1; //Minimum amount for the timer.
    public int timerMax = 10; //Maximum amount for the timer.
    private int timer; //A timer to randomize when the object starts lifting off.

    //Variables for playing sound.
    private AudioSource liftOffSound; //Contains the sound to play when lifting off.
    public AudioClip[] soundClips;
    private bool soundPlaying = false; //Boolean to keep track of wether the lift off sound is already playing.
    public float attackRadius;
    private bool inRange;
    public bool isActive = false;

    public PlayerHealth playerHealth;
    private bool takenDamage;
    public int damage;

    private void Start()
    {
        timer = Random.Range(timerMin, timerMax); //Set the timer to a random number between 10 and 500.
        liftOffSound = (AudioSource)GetComponent(typeof(AudioSource));
        if (target == null)
        {
            target = GameObject.Find("FPSController").transform;
        }
    }

    void Update ()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= attackRadius)
        {
            inRange = true;
        }
        
        //Lifting off
        timer -= 1; //Subracts 1 from the timer varaible each frame.
        if (timer <= 0 && inRange == true && isActive) //If the time reaches zero
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotateSpeed, transform.eulerAngles.z); //Start rotating in the y direction by an amount of degrees specified by the rotateSpeed variable.

            if (rotateSpeed <= maxRotateSpeed) //If the rotate speed is below 50 
            {
                liftOffSpeed = rotateSpeed * liftOffSpeedModifier; //set the liftoff speed to the rotateSpeed * the liftOffSpeedModifier.
                rotateSpeed *= rotateSpeedModifier; //multiply the rotateSpeed by the rotateSpeedModifier.
            }
            if (rotateSpeed >= minRotateSpeed && heightIncrease <= maxHeight) //If the rotateSpeed is above the minRotateSpeed and the current x position is below the starting x value + the max x value.
            {
                transform.position += Vector3.up * Time.deltaTime * liftOffSpeed; //Move the object up by the value of liftOffSpeed each frame.
                heightIncrease += Time.deltaTime * liftOffSpeed; //Update the height increase so we know how far we have moved on the y axis.

                if (soundPlaying == false) //if the sound is not already playing
                {
                    AudioClip randomClip = soundClips[Random.Range(0, soundClips.Length)];
                    liftOffSound.clip = randomClip;
                    liftOffSound.Play(); //Play the lift off sound.
                    soundPlaying = true; //Set the sound playing boolean to true.
                }
            }
        }

        //Flying towards a target
        float step = speed * Time.deltaTime; //determines the steps in which the Vector3.moveTowards moves towards it's target.

        if (heightIncrease >= maxHeight) //if the rotateSpeed is at or above its maximum
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step); //Move towards the target
            if (Vector3.Distance(transform.position, target.position) <= 2) //If the target is reached
            {
                liftOffSound.Stop(); //stop the lift off sound.
                soundPlaying = false;
                if (playerHealth != null && takenDamage == false)
                {
                    playerHealth.TakeDamage(damage);
                    takenDamage = true;
                }
                Destroy(this.gameObject); //DIE
            }
        }
	}

    public void Activate()
    {
        isActive = true;
    }
}
