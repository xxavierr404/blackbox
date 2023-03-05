using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var rotationVector = new Vector3(Input.GetAxis("Mouse Y") * -1, 0);
        transform.Rotate(rotationVector, Space.Self);
    }
}