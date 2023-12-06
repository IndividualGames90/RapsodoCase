using UnityEngine;

namespace Rapsodo.IndividualGames.NPC
{
    /// <summary>
    /// Animation controlls for NPC
    /// </summary>
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private bool _dancing;

        public void ToggleAnimation()
        {
            _dancing = !_dancing;
            _animator.SetBool(AnimationParams.Dancing, _dancing);
        }
    }
}