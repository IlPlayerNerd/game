using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementIlPlayerNerd : MonoBehaviour
{
    Rigidbody rb;
    public bool canMove = true;
    Vector3 moveTo = Vector3.zero;

    public float speed = 10f;
    public float jumpForce = 100f;
    public bool isGrounded = true;

    //// Start is called before the first frame update
    void Start()
    {
        //getting the game obj's rb
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //to get input form  unity's input system
        float z = Input.GetAxisRaw("Horizontal");
        float x = Input.GetAxisRaw("Vertical");

        moveTo = transform.forward * x + transform.right * z;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            //moving the player with rb, and also making it frame independant by mulktiplying by Time.deltaTime
            rb.MovePosition(transform.position + moveTo * speed * Time.deltaTime);

            if (Input.GetButton("Jump") && isGrounded)
            {
                print("jump");
                rb.velocity = (new Vector3(rb.velocity[0], jumpForce, rb.velocity[2]));
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor") {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            print("jumped");
            isGrounded = false;
        }
    }
}
