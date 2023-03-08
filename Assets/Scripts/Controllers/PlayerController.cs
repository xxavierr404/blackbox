using Objects;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSensitivity;
        [SerializeField] private float jumpForce;
        [SerializeField] private int maxJumpCount;

        private const float JumpDelay = 0.2f;
        private int _currentMaxJumpCount;
        private float _currentMovementSpeed;
        private int _jumpCount;
        private float _framesUntilNextJump;

        private void Start()
        {
            _framesUntilNextJump = 0;
            ResetMovementSpeed();
            ResetMaxJumpCount();
        }

        private void Update()
        {
            MovePlayer(GetMovementVector());
            RotatePlayer(new Vector3(0, Input.GetAxis("Mouse X"), 0));
            
            if (Input.GetKeyDown(KeyCode.E)
                && Physics.Raycast(transform.position, transform.forward, out var hit, 5f))
            {
                var clipboard = hit.collider.GetComponent<Clipboard>();
                if (clipboard)
                {
                    clipboard.Activate();
                }
            }
        }

        private void FixedUpdate()
        {
            if (Input.GetAxis("Jump") > 0 && _framesUntilNextJump <= 0)
            {
                Jump();
            }

            if (_framesUntilNextJump > 0)
            {
                _framesUntilNextJump -= Time.deltaTime;
            }
        }

        private void Jump()
        {
            if (_jumpCount >= _currentMaxJumpCount)
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

            _framesUntilNextJump = JumpDelay;
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
