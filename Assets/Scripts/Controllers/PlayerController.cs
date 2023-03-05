using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSensitivity;
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumpCount;

    private const int JumpFrameDelay = 60;
    private int _jumpCount;
    private int _delay;

    private void Start()
    {
        _delay = 0;
    }

    private void Update()
    {
        MovePlayer(GetMovementVector());
        
        RotatePlayer(new Vector3(0, Input.GetAxis("Mouse X"), 0));
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Jump") > 0 && _delay <= 0)
        {
            Jump();
        }

        if (_delay > 0)
        {
            _delay--;
        }
    }

    private void Jump()
    {
        if (_jumpCount >= maxJumpCount)
        {
            if (CheckGround())
            {
                _jumpCount = 0;
            }
            else
            {
                return;
            }
        }

        _delay = JumpFrameDelay;
        _jumpCount++;
        rb.AddForce(new Vector3(0, jumpForce), ForceMode.VelocityChange);
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position - Vector3.down,
            Vector3.down,
            3f);
    }

    private Vector3 GetMovementVector()
    {
        return transform.TransformDirection(new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
            )
        );
    }

    private void MovePlayer(Vector3 movementVector)
    {
        rb.AddForce(movementVector * movementSpeed, ForceMode.Force);
    }

    private void RotatePlayer(Vector3 rotationVector)
    {
        transform.Rotate(rotationVector * rotationSensitivity);
    }
}
