using System;
using UnityEngine.Animations;

namespace UnityEngine.SceneManagement
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeScene : TweenAlpha
    {
        private CanvasGroup _canvasGroup;

        public Action<float> onUpdate;
        public Action onComplete;
        private bool _change;

        protected override void Awake() { base.Awake(); _canvasGroup = GetComponent<CanvasGroup>(); }
        private void Start() { _change = onComplete != null; _alpha = _change ? 0 : 1; if (_change) FadeIn(); else FadeOut(); }
        protected override void OnUpdate(float value) { base.OnUpdate(value); onUpdate?.Invoke(value); _canvasGroup.alpha = value; }
        protected override void OnComplete()
        {
            if (!_change) Destroy(gameObject);
            onComplete?.Invoke();
            base.OnComplete();
        }
    }
}