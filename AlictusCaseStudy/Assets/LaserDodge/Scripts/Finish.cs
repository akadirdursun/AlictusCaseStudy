using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class Finish : MonoBehaviour
    {
        #region MonoBehaviour METHODS
        private void OnTriggerEnter(Collider other)
        {
            StaticEvents.onLevelCompleted?.Invoke();
        }
        #endregion
    }
}