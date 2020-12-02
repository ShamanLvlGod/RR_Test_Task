using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace UI
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Action onDragged;
        public Action onDropped;
        public bool isOverZone = false;
        public Vector3 positionToReturnTo;

        private VectorTweenTask tweenTask;

        public Vector2 DragDistance { get; private set; }

        public void OnBeginDrag(PointerEventData eventData)
        {
            positionToReturnTo = transform.position;
            DragDistance = new Vector2(transform.position.x, transform.position.y) - eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            onDragged?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position + DragDistance;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!isOverZone)
            {
                tweenTask = new VectorTweenTask(pos => { transform.position = pos; }, transform.position,
                    positionToReturnTo,
                    0.3f);
                tweenTask.Start();
            }

            onDropped?.Invoke();
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        private void OnDestroy()
        {
            tweenTask?.Stop();
        }
    }
}