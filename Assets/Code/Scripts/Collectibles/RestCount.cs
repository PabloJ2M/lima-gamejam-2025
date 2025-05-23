using UnityEngine;

public class RestCount : MonoBehaviour
{
    public void RemoveCount()
    {
        if (CManager.collected == 0) return;

        CManager.count -= CManager.collected;
        CManager.collected = 0;
    }
}