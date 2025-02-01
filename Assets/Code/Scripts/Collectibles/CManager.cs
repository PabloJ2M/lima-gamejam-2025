using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;

public class CManager : SingletonBasic<CManager>
{
    [SerializeField] private TextMeshProUGUI cText;
    private int _count;

    private void Start()
    {
        string currentLanguage = LocalizationSettings.SelectedLocale.Identifier.Code;

        if (currentLanguage == "es")
        {
            showMessage($"Tienes: {_count} Colecionables");
        }
        else if (currentLanguage == "en") // Inglés
        {
            showMessage($"You have: {_count} Collectibles");
        }
        
    }
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