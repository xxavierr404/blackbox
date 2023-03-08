using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private const float JumpDelay = 0.2f;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSensitivity;
        [SerializeField] private float jumpForce;
        [SerializeField] private int maxJumpCount;
        private int _currentMaxJumpCount;
        private float _currentMovementSpeed;
        private float _secondsUntilNextJump;
        private int _jumpCount;

        private void Start()
        {
            _secondsUntilNextJump = 0;
            ResetMovementSpeed();
            ResetMaxJumpCount();
        }

        private void Update()
        {
            MovePlayer(GetMovementVector());
            RotatePlayer(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        }

        private void FixedUpdate()
        {
            if (Input.GetAxis("Jump") > 0 && _secondsUntilNextJump <= 0) Jump();

            if (_secondsUntilNextJump > 0) _secondsUntilNextJump -= Time.deltaTime;
        }

        private void Jump()
        {
            if (_jumpCount >= _currentMaxJumpCount)
            {
                if (CheckGround())
                    _jumpCount = 0;
                else
                    return;
            }

            _secondsUntilNextJump = JumpDelay;
            _jumpCount++;
            rigidbody.AddForce(new Vector3(0, jumpForce), ForceMode.VelocityChange);
        }

        private bool CheckGround()
        {
            return Physics.Raycast(transform.position - Vector3.down,
                Vector3.down,
                2f);
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
            rigidbody.AddForce(movementVector * _currentMovementSpeed, ForceMode.Force);
        }

        private void RotatePlayer(Vector3 rotationVector)
        {
            transform.Rotate(rotationVector * rotationSensitivity);
        }

        public void ResetMaxJumpCount()
        {
            _currentMaxJumpCount = maxJumpCount;
        }

        public void SetMaxJumpCount(int count)
        {
            _currentMaxJumpCount = count;
        }

        public void SetMovementSpeed(float speed)
        {
            _currentMovementSpeed = speed;
        }

        public void ResetMovementSpeed()
        {
            _currentMovementSpeed = movementSpeed;
        }
    }
}