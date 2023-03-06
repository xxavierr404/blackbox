using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float verticalSensitivity;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var angularIncrement = verticalSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime * -1;
        var eulerAngles = transform.localEulerAngles;

        if(eulerAngles.x > 180f)
            eulerAngles.x -= 360f;

        eulerAngles.x = Mathf.Clamp(eulerAngles.x + angularIncrement, -90, 90);

        transform.localEulerAngles = eulerAngles;
    }
}