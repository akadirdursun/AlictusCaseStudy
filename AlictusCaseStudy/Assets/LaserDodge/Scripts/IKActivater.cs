using UnityEngine;
using System;
using System.Collections.Generic;
using DitzelGames.FastIK;

namespace Abdulkadir.LaserDodge
{
    public class IKActivater : MonoBehaviour
    {
        private List<FastIKFabric> fastIKFabrics = new List<FastIKFabric>();
        private Animator myAnimator;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            myAnimator = GetComponentInChildren<Animator>();
            fastIKFabrics.AddRange(GetComponentsInChildren<FastIKFabric>());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ActivateFastIK(true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ActivateFastIK(false);
            }
        }
        #endregion

        public void ActivateFastIK(bool value)
        {
            myAnimator.enabled = !value;

            for (int i = 0; i < fastIKFabrics.Count; i++)
            {
                fastIKFabrics[i].SetActive(value);
            }

            LaserDodgeEvents.onIkActivated?.Invoke(value);            
        }
    }
}