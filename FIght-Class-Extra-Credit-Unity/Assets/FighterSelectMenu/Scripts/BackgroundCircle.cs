using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCircle : MonoBehaviour
{
    public float xRotation = 90.0f;
    public float xRotation1 = 0.0f;
    public float RotationSpeed = 2.0f;
    private Vector3 clockwise = new Vector3(0,0,1);
    void Update()
    {
        //transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y, transform.eulerAngles.z);
        transform.Rotate(clockwise * (RotationSpeed * Time.deltaTime));
    }
}
