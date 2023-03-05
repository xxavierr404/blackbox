using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSensitivity;
    [SerializeField] private Collider feetCollider;
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumpCount;

    private int _jumpCount;
    
    private void Update()
    {
        MovePlayer(GetMovementVector());
        RotatePlayer(new Vector3(0, 
            Input.GetAxis("Mouse X"),
            0)
        );
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
