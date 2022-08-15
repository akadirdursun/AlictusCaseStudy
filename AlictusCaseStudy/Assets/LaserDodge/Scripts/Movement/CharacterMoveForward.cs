using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class CharacterMoveForward : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private CharacterAnimationsController animationsController;
        private bool canMove = true;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            animationsController = GetComponentInChildren<CharacterAnimationsController>();
        }
        private void OnEnable()
        {
            animationsController.onFallAnimationCompleted += OnLevelFailed;
            StaticEvents.onLevelCompleted += OnLevelCompleted;
        }

        private void OnDisable()
        {
            animationsController.onFallAnimationCompleted -= OnLevelFailed;
            StaticEvents.onLevelCompleted += OnLevelCompleted;
        }

        private void Update()
        {
            MoveForward();
        }
        #endregion

        #region EVENT LISTENERS
        private void OnLevelFailed()
        {
            canMove = false;
        }

        private void OnLevelCompleted()
        {
            canMove = false;
        }
        #endregion

        private void MoveForward()
        {
            if (!canMove) return;

            transform.position += (Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}