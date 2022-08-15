using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class PlayerStateController : MonoBehaviour
    {
        [SerializeField] private float slowdownScale = 0.15f;
        private CharacterAnimationsController animationsController;
        private IKActivater ikActivater;

        private bool isGameOver;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            ikActivater = GetComponent<IKActivater>();
            animationsController = GetComponentInChildren<CharacterAnimationsController>();
        }

        private void OnEnable()
        {
            animationsController.onJumpAnimationCompleted += OnJumpAnimationCompleted;
            StaticEvents.onLevelFailed += OnObstacleHit;
        }

        private void OnDisable()
        {
            animationsController.onJumpAnimationCompleted -= OnJumpAnimationCompleted;
            StaticEvents.onLevelFailed -= OnObstacleHit;
        }
        #endregion

        #region EVENT LISTENERS
        private void OnJumpAnimationCompleted()
        {
            Time.timeScale = slowdownScale;
            ikActivater.ActivateFastIK(true);
        }

        private void OnObstacleHit()
        {
            if (isGameOver) return;

            isGameOver = true;
            ikActivater.ActivateFastIK(false);
            animationsController.PlayFallAnimation();
            Time.timeScale = 1f;
        }
        #endregion

        public void EnterTheObstacleStage()
        {
            animationsController.PlayJumpAnimation();
        }

        public void ExitTheObstacleStage()
        {
            ikActivater.ActivateFastIK(false);
            animationsController.PlayMoveAnimations();
            Time.timeScale = 1f;
        }        
    }
}