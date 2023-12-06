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
        [Header("Player Data")]
        [SerializeField] private float _moveSpeed = 2f;

        /// <summary> Access player controls. </summary>
        public PlayerControls PlayerControls => _playerControls;
        private PlayerControls _playerControls;
        private Vector3 _playerMovement;
        private const float _gravityFactor = -9.8f;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;

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

        /// <summary> Finalize movement and apply in one step. </summary>
        private void CumulativeMovement()
        {
            _controller.Move(_playerMovement * Time.deltaTime);
            _playerMovement = Vector3.zero;
        }

        /// <summary> Apply gravity continously. </summary>
        private void Gravity()
        {
            _playerMovement.y += _gravityFactor * 10;
        }

        /// <summary> Move the player body. </summary>
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

        /// <summary> Conform to mouse changes. </summary>
        private void MouseLook(Vector2 input)
        {
            if (input == Vector2.zero)
            {
                return;
            }

            transform.LookAt(_lookAt);
        }
    }
}