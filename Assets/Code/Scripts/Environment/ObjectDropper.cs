using System.Collections;
using UnityEngine;

public class ObjectDropper : MonoBehaviour
{
    [SerializeField] private ObjectMovement prefab;
    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField, Range(0, 10)] private float _delay;

    private WaitForSeconds _delayTime;

    private void Awake() => _delayTime = new(_delay);

    private IEnumerator Start()
    {
        yield return _delayTime;
        
        var item = Instantiate(prefab, transform.position, Quaternion.identity);
        item.Direction = transform.up;
        item.Speed = _speed;

        StartCoroutine(Start());
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.up);
    }
}