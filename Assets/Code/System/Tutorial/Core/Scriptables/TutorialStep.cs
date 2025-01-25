using System;

namespace UnityEngine.Tutorial
{
    public enum InteractionType { None, ArrowOnly, Interaction }

    [CreateAssetMenu(fileName = "tutorial step", menuName = "system/tutorial/step", order = 1)]
    public class TutorialStep : ScriptableObject
    {
        [SerializeField] private InteractionType _interaction;
        [Space]
        [SerializeField, TextArea] private string[] _messages;

        public string[] Messages => _messages;

        public InteractionType Interaction { get => _interaction; set => _interaction = value; }
        public Func<RectTransform> onDisplayIndicator;
        public Action onInteractHandler;
    }
}