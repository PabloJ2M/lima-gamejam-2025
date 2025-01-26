using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class ImageSequences : MonoBehaviour
{
    [SerializeField] private TweenCanvasGroup _fade;
    [SerializeField] private AudioSource _source;
    [SerializeField] private UnityEvent _onComplete;
    private RectTransform _transform;

    private void Awake() => _transform = transform as RectTransform;

    private IEnumerator Start()
    {
        int count = transform.childCount;
        Vector3 distance = Vector3.up * _transform.rect.height;

        float fadeTime = _fade.Core.Time;
        WaitForSeconds change = new(fadeTime);
        WaitForSeconds delay = new((_source.clip.length / count) - fadeTime * 2);


        for (int i = 0; i < count; i++)
        {
            yield return delay;

            _fade.FadeOut(); yield return change;

            _transform.localPosition += distance;

            _fade.FadeIn(); yield return change;
        }

        _onComplete.Invoke();
    }
}