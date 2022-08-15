using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class LimbPositionChecker : MonoBehaviour
    {
        [SerializeField] private float checkDistance = 10f;
        [SerializeField] private LayerMask obstacleLayer;

        private MeshRenderer myRenderer;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            myRenderer = GetComponent<MeshRenderer>();
        }

        private void FixedUpdate()
        {
            ObstacleCheck();
        }
        #endregion

        private void ObstacleCheck()
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            //if (Physics.Raycast(transform.position, Vector3.forward, checkDistance, obstacleLayer))
            if (Physics.SphereCast(ray, myRenderer.bounds.extents.x, checkDistance, obstacleLayer))
            {
                myRenderer.material.color = Color.red;
            }
            else
            {
                myRenderer.material.color = Color.green;
            }
        }
    }
}