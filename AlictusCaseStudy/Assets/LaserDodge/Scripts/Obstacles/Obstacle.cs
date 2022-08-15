using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogError("Game Over!!!");
        }
    }
}