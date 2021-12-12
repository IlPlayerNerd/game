using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = Vector3.zero;
    public float distance = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset - (player.transform.forward * distance);
        transform.LookAt(player.transform, Vector3.up);
    }
}
