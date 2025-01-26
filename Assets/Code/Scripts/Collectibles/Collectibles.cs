using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public void Collect() { CManager.Instance.collectCollectible(); Destroy(gameObject); }
}