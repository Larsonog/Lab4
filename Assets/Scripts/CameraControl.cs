using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    //Modified from https://gamedevacademy.org/unity-3d-first-and-third-person-view-tutorial/

    public InputAction wasd;
    public InputAction leftStick;
    public InputAction rightStick;
    public InputAction mouse;
    public InputAction jumpButton;


    public InputAction lockMouse;
    private bool cameraLocked = true;


    public float turnSpeed = 2.0f;
    public float mouseTurnSpeed = 1.0f;

    public float moveSpeed = 2.0f;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    public float jumpForce;
    public bool jumping = false;

    private void OnEnable()
    {
        wasd.Enable();
        leftStick.Enable();
        rightStick.Enable();
        mouse.Enable();
        lockMouse.Enable();
        jumpButton.Enable();



    }
    private void OnDisable()
    {
        wasd.Disable();
        leftStick.Disable();
        rightStick.Disable();
        mouse.Disable();
        lockMouse.Disable();
        jumpButton.Disable();


    }
    void Update()
    {
        MouseAiming();
        KeyboardMovement();
        LockMouse();
        Jump();
    }

    void MouseAiming()
    {
        // get the mouse and joystick inputs

        float y;

        var rightStickRead = rightStick.ReadValue<Vector2>();
        var mouseRead = mouse.ReadValue<Vector2>();

        if (Math.Abs(rightStickRead.x) > 0.01 || Math.Abs(rightStickRead.y) > 0.01)
        {
            y = rightStickRead.x * turnSpeed;
            rotX += rightStickRead.y * turnSpeed;
        }
        else
        {
            y = mouseRead.x * mouseTurnSpeed;
            rotX += mouseRead.y * mouseTurnSpeed;
        }

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }

    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        var buttonPress = wasd.ReadValue<Vector2>();
        var leftStickRead = leftStick.ReadValue<Vector2>();
        if (Math.Abs(leftStickRead.x) > 0.01 || Math.Abs(leftStickRead.y) > 0.01)
        {
            dir.x = leftStickRead.x;
            dir.z = leftStickRead.y;

        }
        else
        {
            dir.x = buttonPress.x;
            dir.z = buttonPress.y;

        }

        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    void LockMouse()
    {
        if (GameManager.Instance.ShouldLockCamera())
        {
            if (lockMouse.triggered)
            {
                cameraLocked = !cameraLocked;
            }
            if (cameraLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    void Jump()
    {
        if(jumpButton.triggered && !jumping)
        {
            var body = gameObject.GetComponent<Rigidbody>();
            body.AddForce(new Vector3(0, jumpForce, 0));
            jumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            jumping = false;
        }
    }
}
