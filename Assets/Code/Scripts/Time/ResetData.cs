using UnityEngine;

public class ResetData : MonoBehaviour
{
    private void Awake()
    {
        Timer.elapsedTime = 0;
        CManager.count = 0;
    }
}