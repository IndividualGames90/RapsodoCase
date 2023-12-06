using UnityEngine;

namespace Rapsodo.IndividualGames.Player
{
    /// <summary>
    /// Player Movement controls.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [Header("Related Components")]
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Transform _lookAt;
        [SerializeField] private Transform _lookAtRotateAround;
        [Header("Player Data")]
        [SerializeField] private float _lookSpeed = 2f;
        [SerializeField] private float _moveSpeed = 2f;

        private PlayerControls _playerControls;
        private Vector3 _playerMovement;
        private const float _gravityFactor = -9.8f;

        private void Awake()
        {
            _playerControls = new();
            _playerControls.Enable();
        }

        private void FixedUpdate()
        {
            MoveBody(_playerControls.PlayerActions.Movement.ReadValue<Vector2>());
            MouseLook(_playerControls.PlayerActions.Look.ReadValue<Vector2>());
            Gravity();
            CumulativeMovement();
        }

        private void CumulativeMovement()
        {
            _controller.Move(_playerMovement * Time.deltaTime);
            _playerMovement = Vector3.zero;
        }

        private void Gravity()
        {
            _playerMovement.y += _gravityFactor * 10;
        }

        private void MoveBody(Vector2 input)
        {
            if (input == Vector2.zero)
            {
                return;
            }

            Vector3 forwardMovement = transform.forward * input.y;
            Vector3 rightMovement = transform.right * input.x;
            _playerMovement = (forwardMovement + rightMovement) * _moveSpeed;
            _playerMovement.y = 0f;
        }

        private void MouseLook(Vector2 input)
        {
            if (input == Vector2.zero)
            {
                return;
            }

            transform.LookAt(_lookAt);

            /*transform.RotateAround(transform.position, Vector3.up, input.x * _lookSpeed);
            transform.RotateAround(transform.position, Vector3.right, -input.y * _lookSpeed);*/

            /*_lookAt.RotateAround(_lookAtRotateAround.position, Vector3.up, input.x);
            _lookAt.RotateAround(_lookAtRotateAround.position, Vector3.right, input.y);
            transform.forward = _lookAt.forward;*/

            //_lookAt.position += new Vector3(input.x, input.y, 0f);
            //_lookAt.position += new Vector3(0, input.y, input.x);
        }
    }
}