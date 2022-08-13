using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class Ring : MonoBehaviour
    {
        [SerializeField] private RingColors color;
        [Space]
        [SerializeField] private List<RingInfo> ringInfoes = new List<RingInfo>();

        #region Properties
        public RingColors Color { get => color; }
        #endregion

        #region MonoBehaviour METHODS   
        private void OnEnable()
        {
            InitializeColor();
        }
        #endregion

        public void OnPick()
        {
        }

        public void OnDrag(Vector3 position)
        {
        }

        public void OnDrop()
        {
        }

        public void InitializeColor()
        {
            //Activate right colored ring
            for (int i = 0; i < ringInfoes.Count; i++)
            {
                if (ringInfoes[i].Color == color)
                {
                    if (ringInfoes[i].RingObject.activeInHierarchy) break; //If right colored ring already active no need to 2nd check

                    ringInfoes[i].RingObject.SetActive(true);
                    continue;
                }
                ringInfoes[i].RingObject.SetActive(false);
            }
        }
    }
}