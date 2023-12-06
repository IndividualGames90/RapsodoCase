using TMPro;
using UnityEngine;

namespace Rapsodo.IndividualGames.UI
{
    /// <summary>
    /// Calculates and prints current FPS.
    /// </summary>
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        private float _deltaTime;
        private int _currentFPS;

        private void Update()
        {
            _deltaTime += (Time.deltaTime - _deltaTime) * .1f;
            _currentFPS = (int)(1.0f / _deltaTime);
            _label.text = _currentFPS.ToString();
        }
    }
}