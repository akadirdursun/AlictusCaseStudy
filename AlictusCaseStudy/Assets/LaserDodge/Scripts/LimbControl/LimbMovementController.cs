using DitzelGames.FastIK;
using UnityEngine;

namespace Abdulkadir.LaserDodge
{
    public class LimbMovementController : MonoBehaviour
    {
        [SerializeField] private LayerMask locaterLayer;

        private bool isActive;

        private Transform pickedLocater;

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            LaserDodgeEvents.onIkActivated += OnIKActivated;
        }

        private void OnDisable()
        {
            LaserDodgeEvents.onIkActivated -= OnIKActivated;
        }

        private void Update()
        {
            if (!isActive) return;

            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
            else if (Input.GetMouseButton(0))
            {
                OnDrag();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                OnDrop();
            }
        }
        #endregion

        #region EVENT LISTENERS
        private void OnIKActivated(bool value)
        {
            isActive = value;
        }
        #endregion

        private void OnClick()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit rayHit, 100f, locaterLayer))
            {
                pickedLocater = rayHit.collider.GetComponent<FastIKFabric>().Target;
            }
        }

        private void OnDrag()
        {
            if (pickedLocater == null) return;

            Vector3 position = GetMousePointOnWorld();
            position.z = pickedLocater.position.z;
            pickedLocater.position = position;
        }

        private void OnDrop()
        {
            pickedLocater = null;
        }

        private Vector3 GetMousePointOnWorld()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = pickedLocater.position.z;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}