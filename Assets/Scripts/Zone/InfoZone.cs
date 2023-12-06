using Rapsodo.IndividualGames.NPC;
using Rapsodo.IndividualGames.Unity;
using TMPro;
using UnityEngine;

namespace Rapsodo.IndividualGames.Zone
{
    /// <summary>
    /// Enabler for assigned info label.
    /// </summary>
    public class InfoZone : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _infoLabel;
        [SerializeField] private AnimationController[] _animationControllers;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                _infoLabel.gameObject.SetActive(true);

                foreach (var item in _animationControllers)
                {
                    item.ToggleAnimation();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                _infoLabel.gameObject.SetActive(false);

                foreach (var item in _animationControllers)
                {
                    item.ToggleAnimation();
                }
            }
        }
    }
}