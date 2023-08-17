using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalMovement : MonoBehaviour
{
    public float movementRange, movementOffset;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f,transform.position.y + movementRange * Mathf.Sin(Time.time + movementOffset),0f);
    }
}
