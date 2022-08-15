using System;
using UnityEngine;


namespace Abdulkadir.LaserDodge
{
    public class CharacterAnimationsController : MonoBehaviour
    {
        private Animator myAnimator;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            myAnimator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            StaticEvents.onLevelCompleted += PlayIdleAnimation;
        }

        private void OnDisable()
        {
            StaticEvents.onLevelCompleted -= PlayIdleAnimation;
        }
        #endregion

        #region EVENTS
        public event Action onJumpAnimationCompleted;
        public event Action onFallAnimationCompleted;
        #endregion

        #region EVENTS LISTENERS
        public void OnJumpAnimationCompleted()
        {
            onJumpAnimationCompleted?.Invoke();
        }

        public void OnFallAnimationCompleted()
        {
            onFallAnimationCompleted?.Invoke();
        }
        #endregion

        public void PlayJumpAnimation()
        {
            myAnimator.SetBool("Jump", true);
        }

        public void PlayMoveAnimations()
        {
            myAnimator.SetBool("Jump", false);
        }

        public void PlayFallAnimation()
        {
            myAnimator.SetTrigger("Fall");
        }

        public void PlayIdleAnimation()
        {
            myAnimator.SetBool("Run", false);
        }
    }
}