using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    /*
    public int rotateSpeed = 200;
    public float CamRotationValue;
    */

    float rotationX = 0;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        //THIS WORKS!!!
        /*if (transform.eulerAngles.x >= 300 && transform.eulerAngles.x <= 360 || transform.eulerAngles.x >= 0 && transform.eulerAngles.x <= 60)
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                transform.Rotate(-rotateSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
            }
        }*/


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}