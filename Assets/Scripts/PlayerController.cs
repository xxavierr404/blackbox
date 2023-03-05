using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSensitivity;

    private void Update()
    {
        var playerRotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);

        var movementVector = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));
        
        movementVector = transform.TransformDirection(movementVector);

        MovePlayer(movementVector);
        RotatePlayer(playerRotation);
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
