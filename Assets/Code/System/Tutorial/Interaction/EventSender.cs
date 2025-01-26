namespace UnityEngine.Tutorial
{
    public abstract class EventSender : MonoBehaviour
    {
        [SerializeField] private TutorialStep _tutorial;

        [ContextMenu("Interact")] public void Interact() => _tutorial.onInteractHandler?.Invoke();
    }
}