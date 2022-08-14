using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.RingStack
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private LayerMask characterLayer;
        [SerializeField] private LayerMask stackLayer;

        private Ring pickedRing;
        private StackPole ringsLastPole;
        private GhostRingManager hoveredGhostRingManager;

        private Vector3 lastPos;
        private Coroutine characterCheckCoroutine;

        #region MonoBehaviour METHODS
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PickTheRing();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                DropTheRing();
            }
            else if (Input.GetMouseButton(0))
            {
                DragTheRing();
            }
        }
        #endregion

        private void PickTheRing()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit rayHit, 100f, stackLayer))
            {
                ringsLastPole = rayHit.collider.GetComponent<StackPole>();
                pickedRing = ringsLastPole.GetTopRing();

                characterCheckCoroutine = StartCoroutine(CharacterStackCheck());
                lastPos = GetMousePointOnWorld();
            }
        }

        private void DragTheRing()
        {
            if (pickedRing == null) return;

            Vector3 currentPos = GetMousePointOnWorld();
            Vector3 movement = currentPos - lastPos;
            lastPos = currentPos;

            pickedRing.OnDrag(movement);
        }

        private void DropTheRing()
        {
            if (characterCheckCoroutine != null)
            {
                StopCoroutine(characterCheckCoroutine);
                characterCheckCoroutine = null;
            }

            if (pickedRing == null) return;

            StackPole hoveredPole = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit rayHit, 100f, characterLayer))
            {
                hoveredPole = rayHit.collider.GetComponentInChildren<StackPole>();
            }

            if (hoveredPole != null && hoveredPole.CanRingStacked(pickedRing))
            {
                hoveredPole.AddNewRing(pickedRing);
            }
            else
            {
                ringsLastPole.AddNewRing(pickedRing);
            }


            //Reset Picked Info
            {
                pickedRing = null;
                ringsLastPole = null;

                if (hoveredGhostRingManager != null)
                {
                    hoveredGhostRingManager.OnLeaveOver();
                    hoveredGhostRingManager = null;
                }
            }
        }

        //Checks if mouse hovering any character and activates the Ghost Rings
        private IEnumerator CharacterStackCheck()
        {
            while (true)
            {
                yield return new WaitForFixedUpdate();

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit rayHit, 999f, characterLayer))
                {
                    GhostRingManager ghostRingManager = rayHit.collider.GetComponent<GhostRingManager>();

                    if (ghostRingManager == null) continue;

                    if (hoveredGhostRingManager == ghostRingManager) continue;

                    if (hoveredGhostRingManager != null)
                        hoveredGhostRingManager.OnLeaveOver();

                    ghostRingManager.OnHoverOver(pickedRing);
                    hoveredGhostRingManager = ghostRingManager;
                }
            }
        }

        private Vector3 GetMousePointOnWorld()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}