using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Action<Transform> onDropped;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;

            Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
            if (draggable != null)
            {
                draggable.isOverZone = true;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;

            Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
            if (draggable != null)
            {
                draggable.isOverZone = false;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
            if (draggable != null)
            {
                draggable.positionToReturnTo = eventData.position+draggable.DragDistance;
                draggable.transform.SetParent(transform);
                onDropped?.Invoke(draggable.transform);
            }
        }
    }
}