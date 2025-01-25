using UnityEngine;
using TMPro;

public class CManager : SingletonBasic<CManager>
{
    [SerializeField] private TextMeshProUGUI cText;
    private int _count;

    private void Start() => showMessage($"Tienes: {_count} Colecionables");
    public void collectCollectible()
    {
        _count++;
        Start();
    }

    private void showMessage(string message)
    {
        cText.text = message;
    }
}