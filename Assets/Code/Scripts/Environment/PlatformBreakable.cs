using System.Collections;
using UnityEngine;

namespace Environment
{
    public class PlatformBreakable : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy, timeToRecovery;

        [SerializeField] private float initialBlinkInterval = 0.5f;
        [SerializeField] private float minBlinkInterval = 0.1f;

        private SpriteRenderer render;
        private Collider2D shape;

        private WaitForSeconds _destroyDelay, _recoveryDelay;
        private Coroutine _effect;

        private void Awake() { render = GetComponent<SpriteRenderer>(); shape = GetComponent<Collider2D>(); }
        private void Start() { _destroyDelay = new(timeToDestroy); _recoveryDelay = new(timeToRecovery); }
        private void OnCollisionEnter2D(Collision2D collision) { if (_effect == null) _effect = StartCoroutine(DestroyItem()); }

        private IEnumerator DestroyItem()
        {
            yield return StartCoroutine(BlinkEffect());
            shape.enabled = render.enabled = false;

            yield return _recoveryDelay; shape.enabled = render.enabled = true;
            _effect = null;
        }

        private IEnumerator BlinkEffect()
        {
            float elapsedTime = 0f;

            while (elapsedTime < timeToDestroy)
            {

                render.enabled = !render.enabled;

                float blinkInterval = Mathf.Lerp(initialBlinkInterval, minBlinkInterval, elapsedTime / timeToDestroy);

                yield return new WaitForSeconds(blinkInterval);

                elapsedTime += blinkInterval;
            }

            render.enabled = true;
        }
    }
}