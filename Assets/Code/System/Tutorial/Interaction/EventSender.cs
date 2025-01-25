using UnityEngine.EventSystems;

namespace UnityEngine.Tutorial
{
    [RequireComponent(typeof(IndicatorFitter))]
    public class EventSender : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TutorialStep _tutorial;

        public void OnPointerDown(PointerEventData eventData) => Interact();
        [ContextMenu("Interact")] public void Interact() => _tutorial.onInteractHandler?.Invoke();
    }
}