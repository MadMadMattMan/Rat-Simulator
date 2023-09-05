using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Kiwi_Movement : MonoBehaviour
{
    public float speed = 1;
    public string AniState;
    public string BeforeUpdate;

    public float InputX;
    public float InputY;

    public Transform KiwiLight;
    public Animator PlayerMovement;

    public float size;

    //an array of different transform positions for the light as we don't understand how to set transform.roation just yet
    public Transform[] KiwiLightPos = new Transform[5];

    void Update()
    {
        //takes the input from the player, (wasd, arrow keys or controller) and turns it into a float between -1 and 1 and stores that value as a varibale (either inputX or inputY) so it can be referanced later
        float inputX = Input.GetAxis("Horizontal");
        InputX = inputX;
        float inputY = Input.GetAxis("Vertical");
        InputY = inputY;

        int Sprint = 1;

        BeforeUpdate = AniState;


        //sprint mechanic if shift is held
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint = 5;
        }

        //actually moves the player by timesing the speed variable with the Input.GetAxis (number between -1 and 1) with Time.delta time to normalise the speed between computers with a sprint vaiable to increse the speed if left shift is held down
        transform.position += new Vector3(speed * inputX * Time.deltaTime * Sprint, speed * inputY * Time.deltaTime * Sprint);
        
        //Standard Vertical and Horizontal Movement
        //if the player moves the joystick along the x axis, the respective horizontal animation will play
        if (inputX > 0 && inputY < 0.25f && inputY > -0.25f)
        {
            PlayerMovement.SetTrigger("MoveSideL");
            AniState = "MoveSideL";
            KiwiLight.rotation = KiwiLightPos[6].rotation;
        }
        else if (inputX < 0 && inputY < 0.25f && inputY > -0.25f)
        {
            PlayerMovement.SetTrigger("MoveSideR");
            AniState = "MoveSideR";
            KiwiLight.rotation = KiwiLightPos[2].rotation;
        }

        //if the player moves the joystick along the y axis, the respective vertical animation will play
        if (inputY > 0 && inputX < 0.25f && inputX > -0.25f)
        {
            PlayerMovement.SetTrigger("MoveUp");
            AniState = "MoveUp";
            KiwiLight.rotation = KiwiLightPos[0].rotation;
        }
        else if (inputY < 0 && inputX < 0.25f && inputX > -0.2f)
        {
            PlayerMovement.SetTrigger("MoveDown");
            AniState = "MoveDown";
            KiwiLight.rotation = KiwiLightPos[4].rotation;
        }


        //More complex diagonal movement animations
        //if the player moves the joystick along the x axis and y axis (diagonal), the respective diagonal animation will play
        ///this code will overide the pror code as it is the latest on the fixed update
        if (inputX > 0.25f && inputY > 0.25f)
        {
            PlayerMovement.SetTrigger("MoveUpDiagR");
            AniState = "MoveUpDiagR";
            KiwiLight.rotation = KiwiLightPos[1].rotation;
        }
        else if (inputX > 0.25f && inputY < 0.25f)
        {
            PlayerMovement.SetTrigger("MoveDownDiagR");
            AniState = "MoveDownDiagR";
            KiwiLight.rotation = KiwiLightPos[3].rotation;
        }
        else if (inputX < 0.25f && inputY > 0.25f)
        {
            PlayerMovement.SetTrigger("MoveUpDiagL");
            AniState = "MoveUpDiagL";
            KiwiLight.rotation = KiwiLightPos[7].rotation;
        }
        else if (inputX < 0.25f && inputY < 0.25f)
        {
            PlayerMovement.SetTrigger("MoveDownDiagL");
            AniState = "MoveDownDiagL";
            KiwiLight.rotation = KiwiLightPos[5].rotation;
        }

        //if the player stops, it will trigger an idle animation
        if (inputX > -0.15f && inputX < 0.15f && inputY > -0.15f && inputY < 0.15f)
        {
            PlayerMovement.SetTrigger("NoInput");
            AniState = "idle";
        }

        if (AniState != BeforeUpdate)
        {
            PlayerMovement.SetTrigger("NoInput");
            AniState = "idle";
        }
    }
}
