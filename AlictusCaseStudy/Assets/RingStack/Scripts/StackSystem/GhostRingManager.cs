using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class GhostRingManager : MonoBehaviour
    {
        [SerializeField] private GhostRing ghostRing;

        private StackPole myStackPole;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            myStackPole = GetComponentInChildren<StackPole>();
        }
        #endregion

        public void OnHoverOver(Ring ring)
        {
            if (myStackPole.CanRingStacked(ring))
            {
                ghostRing.ActivateGhostRing(ring.Color, myStackPole.GetStackPosition());
                ghostRing.gameObject.SetActive(true);
                return;
            }
        }

        public void OnLeaveOver()
        {
            ghostRing.gameObject.SetActive(false);
        }
    }
}