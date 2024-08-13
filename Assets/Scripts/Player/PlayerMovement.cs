using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Input Settings")]
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravityMultiplier = 2f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.5f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody rb;
    private Vector2 moveDirection;
    private bool isGrounded;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que el Rigidbody rote por la física
    }

    private void Update()
    {
        CheckGround();
        MovementInput();
        JumpPlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        Debug.Log(isGrounded);
    }

    private void MovementInput()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        if (moveDirection != Vector2.zero)
        {
            Vector3 moveDir = new Vector3(moveDirection.x * speed, 0, moveDirection.y * speed);
            moveDir = transform.TransformDirection(moveDir);
            moveDir.y = rb.velocity.y;

            rb.velocity = moveDir;
        }
    }


    private void JumpPlayer()
    {
        if (jumpAction.triggered && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(gravityMultiplier * jumpHeight * Mathf.Abs(Physics.gravity.y)), rb.velocity.z);
        }
    }
}
