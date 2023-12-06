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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                _infoLabel.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                _infoLabel.gameObject.SetActive(false);
            }
        }
    }
}