using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class StackManager : MonoBehaviour
    {
        private List<StackPole> stackPoles = new List<StackPole>();

        private Dictionary<RingColors, int> colorCounts = new Dictionary<RingColors, int> { { RingColors.Pink, 0 }, { RingColors.Yellow, 0 }, { RingColors.Green, 0 }, { RingColors.Blue, 0 } };

        #region MonoBehaviour METHODS
        private void Awake()
        {
            stackPoles.AddRange(GetComponentsInChildren<StackPole>());
        }

        private void OnEnable()
        {
            for (int i = 0; i < stackPoles.Count; i++)
            {
                stackPoles[i].onNewRingPlaced += OnRingReplaced;
            }
        }

        private void Start()
        {
            CountTheRings();
        }

        private void OnDisable()
        {
            for (int i = 0; i < stackPoles.Count; i++)
            {
                stackPoles[i].onNewRingPlaced -= OnRingReplaced;
            }
        }
        #endregion

        #region EVENT LISTENERS
        private void OnRingReplaced()
        {
            if (LevelCompletedCheck())
            {
                //TODO: Level Completed
                Debug.LogError("LevelCompleted");
            }
        }
        #endregion

        private void CountTheRings()
        {
            for (int i = 0; i < stackPoles.Count; i++)
            {
                stackPoles[i].CountTheRings(colorCounts);
            }
        }

        private bool LevelCompletedCheck()
        {
            for (int i = 0; i < stackPoles.Count; i++)
            {
                if (!stackPoles[i].IsStackCompleted(colorCounts))
                    return false;
            }

            return true;
        }
    }
}