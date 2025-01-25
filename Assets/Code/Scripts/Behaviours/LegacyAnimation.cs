using System.Collections;
using UnityEngine;

namespace Events.Gameplay
{
    [RequireComponent(typeof(Animation))]
    public class LegacyAnimation : MonoBehaviour
    {
        [SerializeField] private bool _destroyOnComplete;
        private Animation _animation;

        private void Awake() => _animation = GetComponent<Animation>();

        [ContextMenu("Play")] public void StartAnimation()
        {
            _animation.Play();
            if (_destroyOnComplete) StartCoroutine(OnComplete());
        }
        private IEnumerator OnComplete()
        {
            yield return new WaitUntil(() => !_animation.isPlaying);
            Destroy(gameObject);
        }
    }
}