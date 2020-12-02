using UnityEngine;
using Utils;

namespace UI
{
    public class ArcContainer : MonoBehaviour
    {
        [SerializeField] private float radius = 5;
        private Transform child;
        TweenTask tweenTask;

        private void Start()
        {
            ApplyArc();
        }

        public void ApplyArc()
        {
            if (transform.childCount > 0)
            {
                child = transform.GetChild(0);
                child.position += Vector3.up * radius;
            }
        }

        public void StartTween(float startVal, float targetVal)
        {
            child.GetComponent<CanvasGroup>().blocksRaycasts = false;
            if (tweenTask == null)
            {
                tweenTask = new TweenTask(
                    tweenAngle =>
                    {
                        if (transform != null)
                        {
                            transform.localEulerAngles = Vector3.forward * tweenAngle;
                        }
                    }, startVal,
                    targetVal, 0.5f);

                tweenTask.OnComplete += () =>
                {
                    child.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    tweenTask = null;
                };

                tweenTask.Start();
            }
        }

        private void OnDestroy()
        {
            tweenTask?.Stop();
        }
    }
}