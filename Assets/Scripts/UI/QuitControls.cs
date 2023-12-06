using Rapsodo.IndividualGames.Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rapsodo.IndividualGames.UI
{
    /// <summary>
    /// ESC controls to quit the game.
    /// </summary>
    public class QuitControls : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _quitLabel;
        [SerializeField] private PlayerController _playerController;

        private int _quitCount = 0;

        private void Awake()
        {
            _playerController.PlayerControls.PlayerActions.Quit.started += OnQuitPress;
        }

        private void OnQuitPress(InputAction.CallbackContext context)
        {
            _quitCount++;

            if (_quitCount == 1)
            {
                _quitLabel.gameObject.SetActive(true);
            }
            else if (_quitCount == 2)
            {
                Application.Quit();
            }
        }
    }
}