using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Kiwi_Movement2 : MonoBehaviour
{
    public float speed = 1;

    public float InputX;
    public float InputY;
    public Transform CurrentRotation;
    public string State = "idle";
    public string Animation;

    public Transform KiwiLight;
    public Animator PlayerMovement;

    public float size;
    public bool Walking = false;

    public ControllerInputSystem ControllerSupport;
    public Toggle ControllerMode;
    private int Sprint;
    private bool Sprintbool;

    public AudioSource PlayerWalkSFX;

    //an array of different transform positions for the light as we don't understand how to set transform.roation just yet
    public Transform[] KiwiLightPos = new Transform[5];

    private void Awake()
    {
        ControllerSupport = new ControllerInputSystem();
    }

    //Movement
    void FixedUpdate()
    {
        //takes the input from the player, (wasd, arrow keys or controller) and turns it into a float between -1 and 1 and stores that value as a varibale (either inputX or inputY) so it can be referanced later
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        //sprint mechanic if shift is held
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint = 3;
        }

        //moves the player along the X axis in relation to Horizontal Movement Axis, excludes movement if below controller dead zone
        if (InputX > 0.25 || InputX < -0.25)
        {
            transform.position += new Vector3(speed * InputX * Time.deltaTime * Sprint, 0);
        }

        //moves the player along the Y axis in relation to Horizontal Movement Axis, excludes movement if below controller dead zone
        if (InputY > 0.25 || InputY < -0.25)
            transform.position += new Vector3(0, speed * InputY * Time.deltaTime * Sprint);


        //Sets light roation, the variable for roation sector and the current state of the player (moving or idle) and stores the variables

        ///Vertical and Horizontal
        ////If the players movement x and y axis are between some certain parameters, it will give one of 8 movement directions including a dead zone for stick drift
        if (InputX > 0 && InputY < 0.25f && InputY > -0.25f)
        {
            CurrentRotation = KiwiLightPos[2];
            KiwiLight.rotation = KiwiLightPos[2].rotation;
            State = "moving";
        }
        else if (InputX < 0 && InputY < 0.25f && InputY > -0.25f)
        {
            CurrentRotation = KiwiLightPos[6];
            KiwiLight.rotation = KiwiLightPos[6].rotation;
            State = "moving";
        }

        ///Diagonals 
        if (InputY > 0 && InputX < 0.25f && InputX > -0.25f)
        {
            CurrentRotation = KiwiLightPos[0];
            KiwiLight.rotation = KiwiLightPos[0].rotation;
            State = "moving";
        }
        else if (InputY < 0 && InputX < 0.25f && InputX > -0.2f)
        {
            CurrentRotation = KiwiLightPos[4];
            KiwiLight.rotation = KiwiLightPos[4].rotation;
            State = "moving";
        }
        if (InputX > 0.25f && InputY > 0.25f)
        {
            CurrentRotation = KiwiLightPos[1];
            KiwiLight.rotation = KiwiLightPos[1].rotation;
            State = "moving";
        }
        else if (InputX > 0.25f && InputY < -0.25f)
        {
            CurrentRotation = KiwiLightPos[3];
            KiwiLight.rotation = KiwiLightPos[3].rotation;
            State = "moving";
        }
        else if (InputX < -0.25f && InputY > 0.25f)
        {
            CurrentRotation = KiwiLightPos[7];
            KiwiLight.rotation = KiwiLightPos[7].rotation;
            State = "moving";
        }
        else if (InputX < -0.25f && InputY < -0.25f)
        {
            CurrentRotation = KiwiLightPos[5];
            KiwiLight.rotation = KiwiLightPos[5].rotation;
            State = "moving";
        }

        ///if the player stops, it will set the current stae of the player to idle which will be used later in animating the kiwi
        if (InputX > -0.15f && InputX < 0.15f && InputY > -0.15f && InputY < 0.15f)
        {
            State = "idle";
            if (Walking)
                Walking = false;
        }
        else
        {
            if (!Walking)
                Walking = true;
        }

        //Animations
        if (State == "moving")
        {
            if (CurrentRotation == KiwiLightPos[0]) 
            { 
                PlayerMovement.SetBool("Up", true);

                PlayerMovement.SetBool("UpR", false);
                PlayerMovement.SetBool("SideR", false);
                PlayerMovement.SetBool("DownR", false);
                PlayerMovement.SetBool("Down", false);
                PlayerMovement.SetBool("DownL", false);
                PlayerMovement.SetBool("SideL", false);
                PlayerMovement.SetBool("UpL", false);
            }
            if (CurrentRotation == KiwiLightPos[2]) 
            { 
                PlayerMovement.SetBool("SideR", true);

                PlayerMovement.SetBool("Up", false);
                PlayerMovement.SetBool("UpR", false);
                PlayerMovement.SetBool("DownR", false);
                PlayerMovement.SetBool("Down", false);
                PlayerMovement.SetBool("DownL", false);
                PlayerMovement.SetBool("SideL", false);
                PlayerMovement.SetBool("UpL", false);
            }
            if (CurrentRotation == KiwiLightPos[4]) 
            { 
                PlayerMovement.SetBool("Down", true);

                PlayerMovement.SetBool("Up", false);
                PlayerMovement.SetBool("UpR", false);
                PlayerMovement.SetBool("SideR", false);
                PlayerMovement.SetBool("DownR", false);
                PlayerMovement.SetBool("DownL", false);
                PlayerMovement.SetBool("SideL", false);
                PlayerMovement.SetBool("UpL", false);
            }
            if (CurrentRotation == KiwiLightPos[6]) 
            { 
                PlayerMovement.SetBool("SideL", true);

                PlayerMovement.SetBool("Up", false);
                PlayerMovement.SetBool("UpR", false);
                PlayerMovement.SetBool("SideR", false);
                PlayerMovement.SetBool("DownR", false);
                PlayerMovement.SetBool("Down", false);
                PlayerMovement.SetBool("DownL", false);
                PlayerMovement.SetBool("UpL", false);
            }

            if (CurrentRotation == KiwiLightPos[1]) 
            { 
                PlayerMovement.SetBool("UpR", true);
                
                PlayerMovement.SetBool("Up", false);
                PlayerMovement.SetBool("SideR", false);
                PlayerMovement.SetBool("DownR", false);
                PlayerMovement.SetBool("Down", false);
                PlayerMovement.SetBool("DownL", false);
                PlayerMovement.SetBool("SideL", false);
                PlayerMovement.SetBool("UpL", false);
            }
            if (CurrentRotation == KiwiLightPos[3]) 
            { 
                PlayerMovement.SetBool("DownR", true);

                PlayerMovement.SetBool("Up", false);
                PlayerMovement.SetBool("UpR", false);
                PlayerMovement.SetBool("SideR", false);
                PlayerMovement.SetBool("Down", false);
                PlayerMovement.SetBool("DownL", false);
                PlayerMovement.SetBool("SideL", false);
                PlayerMovement.SetBool("UpL", false);
            }
            if (CurrentRotation == KiwiLightPos[5]) 
            { 
                PlayerMovement.SetBool("DownL", true);

                PlayerMovement.SetBool("Up", false);
                PlayerMovement.SetBool("UpR", false);
                PlayerMovement.SetBool("SideR", false);
                PlayerMovement.SetBool("DownR", false);
                PlayerMovement.SetBool("Down", false);
                PlayerMovement.SetBool("SideL", false);
                PlayerMovement.SetBool("UpL", false);
            }
            if (CurrentRotation == KiwiLightPos[7]) 
            { 
                PlayerMovement.SetBool("UpL", true);

                PlayerMovement.SetBool("Up", false);
                PlayerMovement.SetBool("UpR", false);
                PlayerMovement.SetBool("SideR", false);
                PlayerMovement.SetBool("DownR", false);
                PlayerMovement.SetBool("Down", false);
                PlayerMovement.SetBool("DownL", false);
                PlayerMovement.SetBool("SideL", false);
            }
        }
        else if (State == "idle")
        {
            PlayerMovement.SetBool("Up", false); 
            PlayerMovement.SetBool("UpR", false); 
            PlayerMovement.SetBool("SideR", false); 
            PlayerMovement.SetBool("DownR", false); 
            PlayerMovement.SetBool("Down", false); 
            PlayerMovement.SetBool("DownL", false); 
            PlayerMovement.SetBool("SideL", false);
            PlayerMovement.SetBool("UpL", false);  
        }
        else
        {
            //displays a red error code in the console of the issue
            Debug.LogError("Invalid Movement Animation State");
        }

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, size);
    }

    public void Update()
    {
        if (Walking == true && !PlayerWalkSFX.isPlaying)
        {
            PlayerWalkSFX.Play();
        } 
        else if (Walking == false && PlayerWalkSFX.isPlaying)
        {
            PlayerWalkSFX.Stop();
        }

        if (GameOverviewer.GameOver || GameOverviewer.GameOver)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
