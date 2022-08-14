using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class AnimationController : MonoBehaviour
    {
        private Animator animator;
        private StackPole myStackPole;

        private Animator MyAnimator
        {
            get
            {
                if (animator == null)
                    animator = GetComponent<Animator>();

                return animator;
            }
        }

        #region MonoBehaviour METHODS
        private void Awake()
        {
            myStackPole = GetComponentInChildren<StackPole>();
        }

        private void OnEnable()
        {
            StaticEvents.onLevelCompleted += OnLevelCompleted;
            myStackPole.onNewRingPlaced += OnRingPlaced;
            myStackPole.onRingRemoved += OnRingRemoved;
        }

        private void OnDisable()
        {
            StaticEvents.onLevelCompleted -= OnLevelCompleted;
            myStackPole.onNewRingPlaced -= OnRingPlaced;
            myStackPole.onRingRemoved -= OnRingRemoved;
        }
        #endregion

        #region EVENT LISTENERS
        private void OnRingPlaced()
        {
            MyAnimator.SetBool("HasRings", myStackPole.HasRings());
            MyAnimator.SetTrigger("RingMoved");
        }
        private void OnRingRemoved()
        {
            MyAnimator.SetBool("HasRings", myStackPole.HasRings());
            MyAnimator.SetTrigger("RingMoved");
        }
        private void OnLevelCompleted()
        {
            MyAnimator.SetTrigger("LevelEnded");
        }
        #endregion
    }
}