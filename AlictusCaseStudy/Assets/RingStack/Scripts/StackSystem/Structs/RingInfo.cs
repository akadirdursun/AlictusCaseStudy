using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    [System.Serializable]
    public struct RingInfo
    {
        [SerializeField] private RingColors color;
        [SerializeField] private GameObject ringObject;

        public RingColors Color { get => color; }
        public GameObject RingObject { get => ringObject; }
    }
}