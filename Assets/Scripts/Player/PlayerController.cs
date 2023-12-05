using UnityEngine;

namespace Rapsodo.IndividualGames.Player
{
    /// <summary>
    /// Player Movement controls.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Transform _lookAt;

        private PlayerControls _playerControls;
        private Vector3 _playerMovement;
        private float _gravityFactor = -9.8f;

        private void Awake()
        {
            _playerControls = new();
            _playerControls.Enable();
        }

        private void FixedUpdate()
        {
            MoveBody(_playerControls.PlayerActions.Movement.ReadValue<Vector2>());
            MouseLook(_playerControls.PlayerActions.Movement.ReadValue<Vector2>());
            CumulativeMovement();
        }

        private void CumulativeMovement()
        {
            _controller.Move(_playerMovement);
            _playerMovement = Vector3.zero;
        }

        private void MoveBody(Vector2 input)
        {
            if (input == Vector2.zero)
            {
                return;
            }

            _playerMovement = new(-input.y, 0f, input.x);
            _playerMovement.y += _gravityFactor;
        }

        private void MouseLook(Vector2 input)
        {
            if (input == Vector2.zero)
            {
                return;
            }


        }
    }
}