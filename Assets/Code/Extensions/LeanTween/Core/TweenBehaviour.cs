using System;

namespace UnityEngine.Animations
{
    public interface ITweenBehaviour
    {
        public Action onStart { get; set; }
        public Action onComplete { get; set; }
    }

    [RequireComponent(typeof(TweenCore))]
    public abstract class TweenBehaviour<T> : MonoBehaviour, ITweenBehaviour
    {
        [SerializeField] protected AnimationCurve _animationCurve = new(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

        protected TweenCore _tweenCore;
        protected GameObject _self;
        protected int _tweenID = -1;

        public TweenCore Core => _tweenCore;
        public Action onStart { get; set; }
        public Action onComplete { get; set; }

        protected virtual void Awake() { _self = gameObject; _tweenCore = GetComponent<TweenCore>(); }
        protected virtual void OnEnable() => _tweenCore.onPlayStatusChanged += OnPerformePlay;
        protected virtual void OnDisable() => _tweenCore.onPlayStatusChanged -= OnPerformePlay;

        protected abstract void OnUpdate(T value);
        protected virtual void OnPerformePlay(bool value) { onStart?.Invoke(); }
        protected virtual void OnComplete() { _tweenID = -1; onComplete?.Invoke(); }
        protected virtual void CancelTween() { if (_tweenID >= 0) LeanTween.cancel(_tweenID); }
    }
}