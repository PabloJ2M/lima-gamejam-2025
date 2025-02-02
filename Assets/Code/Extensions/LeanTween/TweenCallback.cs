using UnityEngine.Events;

namespace UnityEngine.Animations
{
    [RequireComponent(typeof(ITweenBehaviour))]
    public class TweenCallback : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onStart, _onComplete;

        private ITweenBehaviour _behaviour;

        private void Awake() => _behaviour = GetComponent<ITweenBehaviour>();

        private void OnEnable()
        {
            _behaviour.onStart += _onStart.Invoke;
            _behaviour.onComplete += _onComplete.Invoke;
        }
        private void OnDisable()
        {
            _behaviour.onStart -= _onStart.Invoke;
            _behaviour.onComplete -= _onComplete.Invoke;
        }
    }
}