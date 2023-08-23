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

    public Transform[] KiwiLightPos = new Transform[5];

    //unity told me to add this in
    [System.Obsolete]
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

        //Sets the scale of the kiwi to flip the sprite if the player is moving left
        if (inputX < 0)
        {
            transform.localScale = new Vector3(-size, size, size);
        }
        else
        {
            transform.localScale = new Vector3(size, size, size);
        }

        //animation bools from the animater is toggled depending on the players movement
        if (inputX < 0 || inputX > 0)
        {
            PlayerMovement.SetBool("MovingSide", true);
            KiwiLight.rotation = KiwiLightPos[2].rotation;
        }
        else if (PlayerMovement.GetBool("MovingSide"))
        {
            PlayerMovement.SetBool("MovingSide", false);
        }

        //Animation Code cont.
        if (inputY < 0)
        {
            PlayerMovement.SetBool("MovingDown", true);
            KiwiLight.rotation = KiwiLightPos[4].rotation;
        }
        else if (PlayerMovement.GetBool("MovingDown"))
        {
            PlayerMovement.SetBool("MovingDown", false);
        }
        //Animation Code cont.
        if (inputY > 0)
        {
            PlayerMovement.SetBool("MovingUp", true);
            KiwiLight.rotation = KiwiLightPos[0].rotation;
        }
        else if (PlayerMovement.GetBool("MovingUp"))
        {
            PlayerMovement.SetBool("MovingUp", false);
        }

        //MovingUpDiag animation bool from the animater is toggled depending on the players movement
        if (inputX != 0 && inputY > 0.25f)
        {
            PlayerMovement.SetBool("MovingUpDiag", true);
            KiwiLight.rotation = KiwiLightPos[1].rotation;
        }
        else if (PlayerMovement.GetBool("MovingUpDiag"))
        {
            PlayerMovement.SetBool("MovingUpDiag", false);
        }

        //MovingDownDiag animation bool from the animater is toggled depending on the players movement
        if (inputX != 0 && inputY < -0.25f)
        {
            PlayerMovement.SetBool("MovingDownDiag", true);
            KiwiLight.rotation = KiwiLightPos[3].rotation;
        }
        else if (PlayerMovement.GetBool("MovingDownDiag"))
        {
            PlayerMovement.SetBool("MovingDownDiag", false);
        }
    }
}
