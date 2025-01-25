using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CManager.Instance.collectCollectible();
            Destroy(gameObject);
        }
    }
}