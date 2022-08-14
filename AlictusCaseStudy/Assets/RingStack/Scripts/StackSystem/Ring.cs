using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class Ring : MonoBehaviour
    {
        [SerializeField] private RingColors color;
        [Space]
        [SerializeField] private List<RingInfo> ringInfos = new List<RingInfo>();

        private RingMovementController myMovementController;

        #region Properties
        public RingColors Color { get => color; }
        #endregion

        #region MonoBehaviour METHODS   
        private void Awake()
        {
            myMovementController = GetComponent<RingMovementController>();
        }
        private void OnEnable()
        {
            InitializeColor();
        }
        #endregion

        public void OnPick()
        {
            myMovementController.OnPickSequence();
        }

        public void OnDrag(Vector3 movement)
        {
            myMovementController.MoveTo(movement);
        }

        public void OnDrop(Vector3 stackPosition)
        {
            myMovementController.OnDropSequence(stackPosition);
        }

        public void InitializeColor()
        {
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