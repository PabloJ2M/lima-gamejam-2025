using System.Collections;
using UnityEngine;

public class FinalAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    private Character2D _character;

    private void Awake() => _character = GetComponent<Character2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_character.IsEnabled) return;
        if (!collision.CompareTag("Respawn") && !collision.CompareTag("Finish")) return;
        if (collision.CompareTag("Respawn")) StartCoroutine(DeathAnimation());
        if (collision.CompareTag("Finish")) SuccessAnimation();

        _character.IsEnabled = false;
        _character.body.velocity = Vector2.zero;
    }
    private void SuccessAnimation() => _character.animator.SetTrigger("Victory");
    private IEnumerator DeathAnimation()
    {
        float t = 0;
        _character.animator.SetTrigger("Death");
        Vector2 point = _character.body.position;

        while (t <= 1)
        {
            yield return null;
            t += Time.deltaTime;
            _character.body.position = point + Vector2.up * _curve.Evaluate(t);
        }
    }
}