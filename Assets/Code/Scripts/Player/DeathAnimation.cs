using System.Collections;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    private Character2D _character;
    private Vector2 _point;

    private void Awake() => _character = GetComponent<Character2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_character.IsEnabled) return;
        if (!collision.CompareTag("Respawn")) return;

        _character.animator.SetTrigger("Death");
        _point = _character.body.position;
        _character.IsEnabled = false;
        _character.shape.enabled = false;
        _character.body.isKinematic = true;
        StartCoroutine(Animation());
    }
    private IEnumerator Animation()
    {
        float t = 0;
        while (t <= 1)
        {
            yield return null;
            t += Time.deltaTime;
            _character.body.position = _point + Vector2.up * _curve.Evaluate(t);
        }
    }
}