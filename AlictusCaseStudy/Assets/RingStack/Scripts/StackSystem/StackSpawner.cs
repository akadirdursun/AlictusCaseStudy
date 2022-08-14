using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Abdulkadir.RingStack
{
    public class StackSpawner : MonoBehaviour
    {
        [SerializeField] private Ring ringPrefab;
        [Space]
        [SerializeField] private int spawnCount;

        private StackPole myStackPole;

        public StackPole MyStackPole
        {
            get
            {
                if (myStackPole == null)
                    myStackPole = GetComponent<StackPole>();

                return myStackPole;
            }
        }

#if UNITY_EDITOR
        public void SpawnRings()
        {
            if (MyStackPole == null) return;

            ClearRings();

            List<Ring> spawnedRings = new List<Ring>();

            for (int i = 0; i < spawnCount; i++)
            {
                Ring newRing = PrefabUtility.InstantiatePrefab(ringPrefab, transform) as Ring;
                newRing.InitializeColor();
                spawnedRings.Add(newRing);
            }

            MyStackPole.SetStackPositions(spawnedRings);
            EditorUtility.SetDirty(MyStackPole);
        }

        public void ClearRings()
        {
            while (transform.childCount > 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
#endif
    }
}