using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Kiwi_Movement : MonoBehaviour
{
    public float speed = 1;
    public float XInput;
    public float YInput;

    public Transform KiwiLight;
    public Animator PlayerMovement;

    public float size;

    //an array of different transform positions for the light as we don't understand how to set transform.roation just yet
    public Transform[] KiwiLightPos = new Transform[5];

    void Update()
    {
        //takes the input from the player, (wasd, arrow keys or controller) and turns it into a float between -1 and 1 and stores that value as a varibale (either inputX or inputY) so it can be referanced later
        float inputX = Input.GetAxis("Horizontal");
        XInput = inputX;
        float inputY = Input.GetAxis("Vertical");
        YInput = inputY;
        int Sprint;

        //sprint mechanic if shift is held
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint = 5;
        }
        else
        {
            Sprint = 1;
        }

        //actually moves the player by timesing the speed variable with the Input.GetAxis (number between -1 and 1) with Time.delta time to normalise the speed between computers with a sprint vaiable to increse the speed if left shift is held down
        transform.position += new Vector3(speed * inputX * Time.deltaTime * Sprint, speed * inputY * Time.deltaTime * Sprint);

        //animation bools from the animater is toggled depending on the players movement
        if (inputX < 0 || inputX > 0)
        {
            
        }
    }
}
