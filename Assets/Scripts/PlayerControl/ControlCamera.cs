using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Axis
{
    Horizontal,
    Vertical,
    Diagonal
}

public class ControlCamera : MonoBehaviour
{
    [SerializeField] private Axis _typeAxisControl;

    [SerializeField] float _sensitive;

    private float deltaX;
    private float deltaY;

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
            deltaY = _sensitive * -Input.GetAxis("Mouse Y");

            Vector3 rotation = new Vector3(deltaY, 0, 0);

            rotation *= Time.deltaTime;

            transform.Rotate(rotation);
        }
        else
        {
            deltaX = _sensitive * Input.GetAxis("Mouse X");
            deltaY = _sensitive * -Input.GetAxis("Mouse Y");

            Vector3 rotate = new Vector3(deltaY, deltaX, 0);

            rotate *= Time.deltaTime;

            transform.Rotate(rotate);

            rotate = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);

            transform.localEulerAngles = rotate;
        }
    }
}
