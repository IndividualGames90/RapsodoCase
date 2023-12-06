using Rapsodo.IndividualGames.Unity;
using UnityEngine;

namespace Rapsodo.IndividualGames.Zone
{
    /// <summary>
    /// Quits game when entered.
    /// </summary>
    public class QuitZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                Application.Quit();
            }
        }
    }
}