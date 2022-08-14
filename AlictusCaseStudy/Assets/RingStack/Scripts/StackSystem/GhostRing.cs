using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class GhostRing : MonoBehaviour
    {
        [SerializeField] private List<RingInfo> ringInfos = new List<RingInfo>();

        public void ActivateGhostRing(RingColors color, Vector3 stackPosition)
        {
            transform.localPosition = stackPosition;
            //Activate right colored ring
            for (int i = 0; i < ringInfos.Count; i++)
            {
                if (ringInfos[i].Color == color)
                {
                    if (ringInfos[i].RingObject.activeInHierarchy) break; //If right colored ring already active no need to 2nd check

                    ringInfos[i].RingObject.SetActive(true);
                    continue;
                }
                ringInfos[i].RingObject.SetActive(false);
            }
        }
    }
}