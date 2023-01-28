using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBody : MonoBehaviour
{
    [SerializeField] private Axis _typeAxisControl;

    [SerializeField] float _speed;

    private CharacterController controller;

    private float deltaX;
    private float deltaY;

    private float gravity = -9.08f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (_typeAxisControl == Axis.Horizontal)
        {
            deltaX = _speed * Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(deltaX, 0, 0);

            movement *= Time.deltaTime;

            controller.Move(movement);
        }
        else if (_typeAxisControl == Axis.Vertical)
        {
            deltaY = _speed * Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(0, 0, deltaY);

            movement *= Time.deltaTime;

            controller.Move(movement);
        }
        else
        {
            deltaX = _speed * Input.GetAxis("Horizontal");
            deltaY = _speed * Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(deltaX, gravity, deltaY);

            movement *= Time.deltaTime;

            movement = transform.TransformDirection(movement);

            controller.Move(movement);
        }
    }
}
