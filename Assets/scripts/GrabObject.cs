using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    KeyCode grabKeyCode = KeyCode.E;
    public float maxGrabDistance = 5f;
    public float grabDistance = 1f;
    public float smoothness = 2f;

    Transform objGrabbed = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(grabKeyCode)) {
            if (objGrabbed)
            {
                DropObj();
            }
            else
            {
                RaycastHit hit;
                bool hasHit = Physics.Raycast(transform.position, transform.forward, out hit, maxGrabDistance);
                if (hasHit)
                { 
                    if (hit.collider.gameObject.tag == "grabbable")
                    {
                        GrabObj(hit.collider.transform);
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (objGrabbed)
        {
            MoveObj();
        }
    }

    void MoveObj() {
        Vector3 newPosition;
        newPosition = SmoothMovement(objGrabbed.position, transform.position + transform.forward * grabDistance, smoothness); 

        Rigidbody objRb = objGrabbed.GetComponent<Rigidbody>();
        if (objRb)
        {
            objRb.MovePosition(newPosition);
        }
        else { 
            objGrabbed.position = newPosition;
        }

        objGrabbed.transform.LookAt(transform.position);
    }
    void GrabObj(Transform obj)
    {
        Rigidbody objRb = obj.GetComponent<Rigidbody>();
        objRb.useGravity = false;
        objGrabbed = obj;
    }

    void DropObj()
    {
        Rigidbody objRb = objGrabbed.GetComponent<Rigidbody>();
        objRb.useGravity = true;
        objGrabbed = null;
    }
    Vector3 SmoothMovement(Vector3 currentPos, Vector3 targetPos, float smooth) { //smooth is >0, the higher the smoother but slower
        Vector3 newPosition;

        newPosition = ((targetPos - currentPos) / smooth) * Time.deltaTime; 
        newPosition += currentPos; //calculates where the obj should go  

        return newPosition;
    }
}
