using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CManager : MonoBehaviour //Lo separe en 2 para que sea mas sencillo para mi y no matarme
{
    public static CManager instance;

    [SerializeField] private TextMeshProUGUI cText;

    [SerializeField] private float duration; //cuanto tiempo dura el mensaje

    private bool[] cCollected = new bool[3]; //la cantidad de coleccionables que tiene

    private void Awake()
    {
        instance = this;
    }

    public void collectCollectible(int collectibleID)
    {
        if (collectibleID < 0 || collectibleID >= cCollected.Length || cCollected[collectibleID]) return;
        {
            cCollected[collectibleID] = true;

            showMessage($"Collectible {collectibleID + 1} found"); //mensaje que dice
        }
    }

    private void showMessage(string message)
    {
        cText.text = message;

        cText.gameObject.SetActive(true);

        CancelInvoke(nameof(cancelMessage));

        Invoke(nameof(cancelMessage), duration);
    }

    private void cancelMessage()
    {

        cText?.gameObject.SetActive(false);

    }
}
