using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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

    //an array of different transform positions for the light as we don't understand how to set transform.roation just yet
    public Transform[] KiwiLightPos = new Transform[5];

    void Update()
    {
        //takes the input from the player, (wasd, arrow keys or controller) and turns it into a float between -1 and 1 and stores that value as a varibale (either inputX or inputY) so it can be referanced later
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        int Sprint = 1;

        //sprint mechanic if shift is held
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint = 5;
        }

        //actually moves the player by timesing the speed variable with the Input.GetAxis (number between -1 and 1) with Time.delta time to normalise the speed between computers with a sprint vaiable to increse the speed if left shift is held down
        transform.position += new Vector3(speed * InputX * Time.deltaTime * Sprint, speed * InputY * Time.deltaTime * Sprint);


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
        }

        //Animations
        if (State == "moving")
        {
            if (CurrentRotation == KiwiLightPos[0]) { PlayerMovement.SetBool("Up", true);    }
            if (CurrentRotation == KiwiLightPos[2]) { PlayerMovement.SetBool("SideR", true); }
            if (CurrentRotation == KiwiLightPos[4]) { PlayerMovement.SetBool("Down", true);  }
            if (CurrentRotation == KiwiLightPos[6]) { PlayerMovement.SetBool("SideL", true); }

            if (CurrentRotation == KiwiLightPos[1]) { PlayerMovement.SetBool("UpR", true); }
            if (CurrentRotation == KiwiLightPos[3]) { PlayerMovement.SetBool("DownR", true); }
            if (CurrentRotation == KiwiLightPos[5]) { PlayerMovement.SetBool("DownL", true); }
            if (CurrentRotation == KiwiLightPos[7]) { PlayerMovement.SetBool("UpL", true);   }
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


    }
}
