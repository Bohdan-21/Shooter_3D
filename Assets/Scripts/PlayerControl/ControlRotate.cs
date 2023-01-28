using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Axis
{
    Horizontal,
    Vertical,
    Diagonal
}

public class ControlRotate : MonoBehaviour
{
    [SerializeField] private Axis _typeAxisControl;

    [SerializeField] float _sensitive;

    private float deltaX;
    private float deltaY;

    private float minVert = -45;
    private float maxVert = 45;

    void Update()
    {
        if(_typeAxisControl == Axis.Horizontal)
        {
            deltaX = _sensitive * Input.GetAxis("Mouse X");

            Vector3 rotation = new Vector3(0, deltaX, 0);

            rotation *= Time.deltaTime;

            transform.Rotate(rotation);
        }
        else if (_typeAxisControl == Axis.Vertical)
        {
            deltaY -= _sensitive * Input.GetAxis("Mouse Y");
            deltaY = Mathf.Clamp(deltaY, minVert, maxVert);

            Vector3 rotation = new Vector3(deltaY, 0, 0);

            transform.localEulerAngles = rotation;
        }
        else
        {
            deltaX = _sensitive * Input.GetAxis("Mouse X");
            deltaY -= _sensitive * -Input.GetAxis("Mouse Y");

            Vector3 rotate = new Vector3(deltaY, deltaX, 0);
            
            transform.localEulerAngles = rotate;
        }
    }
}
