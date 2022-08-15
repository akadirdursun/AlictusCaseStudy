using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class LimbMovePointActivater : MonoBehaviour
    {
        [SerializeField] private GameObject sphere;

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            LaserDodgeEvents.onIkActivated += OnIKActivated;
        }

        private void OnDisable()
        {
            LaserDodgeEvents.onIkActivated -= OnIKActivated;
        }
        #endregion

        #region EVENT LISTENER
        private void OnIKActivated(bool value)
        {
            sphere.gameObject.SetActive(value);
        }
        #endregion
    }
}