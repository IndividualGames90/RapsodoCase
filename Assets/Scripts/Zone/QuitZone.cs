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
            Application.Quit();
        }
    }
}