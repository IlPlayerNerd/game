using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementIlPlayerNErd : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveTo = Vector3.zero;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //getting the game obj's rb
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
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
        //moving the player with rb, and also making it frame independant by mulktiplying by Time.deltaTime
        rb.MovePosition(transform.position + moveTo * speed * Time.deltaTime);
    }
}
