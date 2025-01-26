using UnityEngine.EventSystems;

namespace UnityEngine.Tutorial
{
    [RequireComponent(typeof(IndicatorFitter))]
    public class EventClick : EventSender, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData) => Interact();
    }
}