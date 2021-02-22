using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMover : MonoBehaviour
{
    float rotationX = 0;

    public float lookSpeed = 2;
    public float lookXLimit = 45.0f;
    public bool CanMove;


    // Update is called once per frame
    void Update()
    {
        if (CanMove && Time.timeScale != 0)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
