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

    public float size;
    public Sprite KiwiDown0;
    public Sprite KiwiDown1;
    public Sprite KiwiDown2;
    public Sprite KiwiUp0;
    public Sprite KiwiUp1;
    public Sprite KiwiUp2;
    public Sprite KiwiSide0;
    public Sprite KiwiSide1;
    public Sprite KiwiSide2;

    private bool AnimateUp;
    private bool AnimateDown;
    private bool AnimateSide;
    public float AnimationSpeed;

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
            AnimateUp = false;
            AnimateSide = false;
            if (!AnimateDown)
            {
                StartCoroutine(DownAniation());
                AnimateDown = true;
            }
            transform.localScale = new Vector3(size, size, size);
        }
        else if (inputY > 0)
        {
            AnimateDown = false;
            AnimateSide = false;
            if (!AnimateUp)
            {
                StartCoroutine(UpAniation());
                AnimateUp = true;
            }
            transform.localScale = new Vector3(size, size, size);
        }
        else if (inputX < 0)
        {
            AnimateDown = false;
            AnimateUp = false;
            if (!AnimateSide)
            {
                StartCoroutine(SideAniation());
                AnimateSide = true;
            }
            transform.localScale = new Vector3(-size, size, size);
        }
        else if (inputX > 0)
        {
            AnimateDown = false;
            AnimateUp = false;
            if (!AnimateSide)
            {
                StartCoroutine(DownAniation());
                AnimateSide = true;
            }
            transform.localScale = new Vector3(size, size, size);
        }


    }

    public IEnumerator UpAniation()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiUp0;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiUp1;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiUp0;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiUp2;
        yield return new WaitForSeconds(AnimationSpeed);
        AnimateUp = false;
    }
    public IEnumerator DownAniation()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiDown0;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiDown1;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiDown0;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiDown2;
        yield return new WaitForSeconds(AnimationSpeed);
        AnimateDown = false;
    }
    public IEnumerator SideAniation()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiSide0;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiSide1;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiSide0;
        yield return new WaitForSeconds(AnimationSpeed);
        gameObject.GetComponent<SpriteRenderer>().sprite = KiwiSide2;
        yield return new WaitForSeconds(AnimationSpeed);
        AnimateSide = false;
    }
}
