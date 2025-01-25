namespace UnityEngine.Tutorial
{
    [RequireComponent(typeof(TutorialController))]
    public class EventHandler : TutorialBehaviour
    {
        private TutorialStep _lastTutorial;

        public void TriggerEvent() => _controller.Continue = true;

        protected override void OnPerformeTutorial(TutorialStep newTutorial)
        {
            if (_lastTutorial) _lastTutorial.onInteractHandler = null;
            if (newTutorial.Interaction != InteractionType.Interaction) return;
            
            _lastTutorial = newTutorial;
            _lastTutorial.onInteractHandler = TriggerEvent;
        }
    }
}