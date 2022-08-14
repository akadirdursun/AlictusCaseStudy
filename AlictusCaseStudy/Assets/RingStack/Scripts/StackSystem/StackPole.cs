using System;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class StackPole : MonoBehaviour
    {
        [SerializeField] private List<Vector3> positions = new List<Vector3>();
        [SerializeField] private List<Ring> ringList = new List<Ring>();

        [SerializeField][HideInInspector] private float height;

        #region EVENTS
        public event Action onNewRingPlaced;
        public event Action onRingRemoved;
        #endregion

        public void SetStackPositions(List<Ring> ringList)
        {
            positions.Clear();
            this.ringList.Clear();

            this.ringList = ringList;
            height = ringList[0].GetComponentInChildren<MeshRenderer>(true).bounds.size.y;

            for (int i = 0; i < ringList.Count; i++)
            {
                Vector3 newpos = GetStackPosition(i);

                ringList[i].transform.localPosition = newpos;
            }
        }

        public void CountTheRings(Dictionary<RingColors, int> ringCount)
        {
            for (int i = 0; i < ringList.Count; i++)
            {
                ringCount[ringList[i].Color] += 1;
            }
        }

        //Checks if same colored rings stack in one pole
        public bool IsStackCompleted(Dictionary<RingColors, int> ringCount)
        {
            if (ringList.Count == 0) return true;

            RingColors stackColor = ringList[0].Color;

            if (ringCount[stackColor] != ringList.Count) return false; //if same color counts is not equal to the stack count means there are another colored ring in the stack

            for (int i = 0; i < ringList.Count; i++) //Check if stacked rings all colored as stackColor
            {
                if (ringList[i].Color != stackColor)
                    return false;
            }

            return true;
        }

        public void AddNewRing(Ring ring)
        {
            ring.transform.SetParent(transform);
            ring.OnDrop(GetStackPosition());
            ringList.Add(ring);

            onNewRingPlaced?.Invoke();
        }

        public Ring GetTopRing()
        {
            Ring ring = ringList[ringList.Count - 1];
            ringList.Remove(ring);
            ring.OnPick();

            onRingRemoved?.Invoke();
            return ring;
        }


        public bool CanRingStacked(Ring ring)
        {
            if (ringList.Count > 0 && ringList[ringList.Count - 1].Color != ring.Color) return false;

            return true;
        }

        public bool HasRings()
        {
            if (ringList.Count > 0) return true;

            return false;
        }

        public Vector3 GetStackPosition()
        {
            Vector3 stackPosition = Vector3.zero;
            if (positions.Count > ringList.Count)
            {
                stackPosition = positions[ringList.Count];
            }
            else
            {
                stackPosition.y = ringList.Count * height;
                positions.Add(stackPosition);
            }
            return stackPosition;
        }

        private Vector3 GetStackPosition(int index)
        {
            Vector3 stackPosition = Vector3.zero;
            if (positions.Count > ringList.Count)
            {
                stackPosition = positions[ringList.Count];
            }
            else
            {
                stackPosition.y = index * height;
                positions.Add(stackPosition);
            }
            return stackPosition;
        }
    }
}