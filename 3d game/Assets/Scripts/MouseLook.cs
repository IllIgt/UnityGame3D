using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivityHor = 9.0f; 
    public float sensitivityVert = 9.0f;

    public float maximumVert = 45.0f;
    public float minimumVert = -45.0f;

    private float _rotationX = 0;
    // Update is called once per frame
    void Update()
    {
        switch (axes)
        {
            case RotationAxes.MouseXandY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float rotationY = transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * sensitivityHor);
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); 
                break;
            case RotationAxes.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
                break;
            case RotationAxes.MouseY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
                break;
        }
    }
}
