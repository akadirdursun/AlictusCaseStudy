using UnityEngine;
using UnityEditor;

namespace Abdulkadir.RingStack
{
    [CustomEditor(typeof(StackSpawner))]
    public class StackSpawnerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            StackSpawner stackSpawner = (StackSpawner)target;

            if (GUILayout.Button("Spawn"))
            {
                stackSpawner.SpawnRings();                
            }

            if (GUILayout.Button("Clear"))
            {
                stackSpawner.ClearRings();
            }
        }
    }
}