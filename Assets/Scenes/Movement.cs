using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    //public float speed;

    public float movespeed = 20.0f;
    float horizontal;
    float vertical;
    float movelimit = 0.7f;
    float rotspeed = 10;
    float hor;
    float ver;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        //rb2d.AddForce(movement*speed);

        horizontal = Input.GetAxisRaw("Horizontal"); // A & D controls
        vertical = Input.GetAxisRaw("Vertical"); // W & S controls

        float rot = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;

        if ((horizontal != 0 && vertical != 0) ^ (horizontal != 0 ^ vertical != 0)) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-180, 0, rot), rotspeed);
        }

    }

    private void FixedUpdate()
    {
        if(horizontal != 0 && vertical != 0)
        {
            horizontal *= movelimit;
            vertical *= movelimit;
        }

        rb2d.velocity = new Vector2(horizontal * movespeed, vertical * movespeed); 
    }

}
