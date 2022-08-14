using UnityEngine;
using DG.Tweening;

namespace Abdulkadir.RingStack
{
    public class RingMovementController : MonoBehaviour
    {
        [SerializeField] private float overHeadPosition = 9f;
        [Space]
        [SerializeField] private float sequenceTime = 0.5f;
        [SerializeField] private float jumpPower = 0.5f;

        private Sequence sequence;

        public void OnPickSequence()
        {
            if (sequence != null)
                sequence.Kill();

            sequence = DOTween.Sequence();
            Tween tween = transform.DOLocalMoveY(overHeadPosition, sequenceTime);
            sequence.Append(tween);

            sequence.OnKill(() =>
            {
                Vector3 localPos = transform.localPosition;
                localPos.y = overHeadPosition;
                transform.localPosition = localPos;

                transform.SetParent(null);
                sequence = null;
            });
        }

        public void OnDropSequence(Vector3 stackPosition)
        {
            if (sequence != null)
                sequence.Kill();

            sequence = DOTween.Sequence();
            Tween tween = transform.DOLocalMove(Vector3.up * overHeadPosition, sequenceTime);
            sequence.Append(tween);
            tween = transform.DOLocalMove(stackPosition, sequenceTime);
            sequence.Append(tween);
            tween = transform.DOLocalJump(stackPosition, jumpPower, 2, sequenceTime);
            sequence.Append(tween);

            sequence.OnKill(() =>
            {
                transform.localPosition = stackPosition;
                sequence = null;
            });
        }

        public void MoveTo(Vector3 movement)
        {
            if (sequence != null) return;

            transform.position += movement;
        }
    }
}