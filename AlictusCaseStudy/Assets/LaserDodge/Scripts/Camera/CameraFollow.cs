using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        #region MonoBehaviour METHODS
        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }
        #endregion
    }
}