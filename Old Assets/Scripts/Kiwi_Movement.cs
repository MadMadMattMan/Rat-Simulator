using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Kiwi_Movement : MonoBehaviour
{
    public float speed = 1;
    public float XInput;
    public float YInput;

    public Animator PlayerMovement;

    public float size;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        XInput = inputX;
        float inputY = Input.GetAxis("Vertical");
        YInput = inputY;
        int Sprint;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint = 5;
        }
        else
        {
            Sprint = 1;
        }
        transform.position += new Vector3(speed * inputX * Time.deltaTime * Sprint, speed * inputY * Time.deltaTime * Sprint);
        if (inputX < 0)
        {
            transform.localScale = new Vector3(-size, size, size);
        }
        else
        {
            transform.localScale = new Vector3(size, size, size);
        }

        if (inputX != 0 && inputY > 0.25f)
        {
            PlayerMovement.SetBool("MovingUpDiag", true);
        }
        else if (PlayerMovement.GetBool("MovingUpDiag"))
        {
            PlayerMovement.SetBool("MovingUpDiag", false);
        }

        if (inputX != 0 && inputY > -0.25f)
        {
            PlayerMovement.SetBool("MovingDownDiag", true);
        }
        else if (PlayerMovement.GetBool("MovingDownDiag"))
        {
            PlayerMovement.SetBool("MovingDownDiag", false);
        }
    }
}
