using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;

public class CManager : SingletonBasic<CManager>
{
    [SerializeField] private TextMeshProUGUI cText;
    public static int count;
    public static int collected;

    protected override void Awake() { base.Awake(); collected = 0; }

    private void Start()
    {
        string currentLanguage = LocalizationSettings.SelectedLocale.Identifier.Code;

        switch (currentLanguage)
        {
            case "es": showMessage($"Tienes: {count} Colecionables"); break;
            case "en": showMessage($"You have: {count} Collectibles"); break;
        }
    }

    private void showMessage(string message) => cText.SetText(message);
    public void collectCollectible() { collected++; count++; Start(); }
}