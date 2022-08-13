using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class StackPole : MonoBehaviour
    {
        [SerializeField] private List<Vector3> positions = new List<Vector3>();
        [SerializeField] private List<Ring> ringList = new List<Ring>();

        public void SetStackPositions(List<Ring> ringList)
        {
            this.ringList = ringList;
            float height = ringList[0].GetComponentInChildren<MeshRenderer>(true).bounds.size.y;

            for (int i = 0; i < ringList.Count; i++)
            {
                Vector3 newpos = Vector3.zero;
                newpos.y = i * height;
                positions.Add(newpos);

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
            RingColors stackColor = ringList[0].Color;

            if (ringCount[stackColor] != ringList.Count) return false; //if same color counts is not equal to the stack count means there are another colored ring in the stack

            for (int i = 0; i < ringList.Count; i++) //Check if stacked rings all colored as stackColor
            {
                if (ringList[i].Color != stackColor)
                    return false;
            }

            return true;
        }
    }
}