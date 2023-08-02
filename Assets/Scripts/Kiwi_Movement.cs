using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Kiwi_Movement : MonoBehaviour
{
    public float speed = 0.0025f;
    public float XInput;
    public float YInput;

    private Rigidbody2D rb;

    public Sprite KiwiDown;
    public Sprite KiwiUp;
    public Sprite KiwiSide;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        XInput = inputX;
        float inputY = Input.GetAxis("Vertical");
        YInput = inputY;

        transform.position += new Vector3(speed * inputX, speed * inputY);
        if (inputY < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = KiwiDown;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputY > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = KiwiUp;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputX < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = KiwiSide;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputX > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = KiwiSide;
            transform.localScale = new Vector3(-1, 1, 1);
        }


    }
}
