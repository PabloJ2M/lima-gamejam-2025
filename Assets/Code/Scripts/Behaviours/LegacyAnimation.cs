using System.Collections;
using UnityEngine;

namespace Events.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class LegacyAnimation : MonoBehaviour
    {
        [SerializeField] private bool _destroyOnComplete;
        private Animator _animation;

        private void Awake() => _animation = GetComponent<Animator>();

        [ContextMenu("Play")] public void StartAnimation()
        {
            _animation.SetTrigger("Play");
            if (_destroyOnComplete) StartCoroutine(OnComplete());
        }
        private IEnumerator OnComplete()
        {
            yield return new WaitForSeconds(_animation.GetCurrentAnimatorClipInfo(0).Length);
            Destroy(gameObject);
        }
    }
}