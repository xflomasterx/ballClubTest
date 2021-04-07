using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Rigidbody rb;
    public float torque;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    float turn;
    public float torqueCurrent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        torqueCurrent = torque;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (torqueCurrent > 0)
        {
            torqueCurrent -= 0.01f;
            rb.AddTorque(transform.right * torqueCurrent * turn, ForceMode.Force);
        }
        
    }
    void Update()
    {
        turn = Swipe();
    }
    public float Swipe()
    {
        //for PC debug
        /*
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            secondPressPos = firstPressPos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            torqueCurrent = torque;
        }*/
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(touch.position.x, touch.position.y);
                secondPressPos = firstPressPos;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(touch.position.x, touch.position.y);
                torqueCurrent = torque;
            }
            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
        }
        return currentSwipe.x;
    }
}
