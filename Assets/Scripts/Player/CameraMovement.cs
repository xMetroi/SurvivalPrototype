using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float mouseSensitivity = 80f;
    [SerializeField] private float minYAngle, maxYAngle;

    private Transform playerBody;
    private float xRotation = 0f;

    private void Start()
    {
        playerBody = transform.parent;
    }

    void Update()
    {
        MovementMouseInput();
    }

    private void MovementMouseInput()
    {
        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (x != 0 || y != 0)
        {
            xRotation -= y;
            xRotation = Mathf.Clamp(xRotation, minYAngle, maxYAngle);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * x);
        }
    }

}
