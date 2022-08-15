using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class ObstacleStateEnter : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerStateController stateController = other.GetComponent<PlayerStateController>();

            if (stateController == null) return;

            stateController.EnterTheObstacleStage();
        }
    }
}