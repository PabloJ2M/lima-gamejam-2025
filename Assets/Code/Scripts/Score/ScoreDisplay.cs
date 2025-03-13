using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
    public ScoreController player1Score;
    public ScoreController player2Score;

    public RectTransform player1Bar;
    public RectTransform player2Bar;

    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public TextMeshProUGUI resultText;

    public float fillSpeed = 1f;
    public float maxBarHeight = 300f;
    public float minBarHeight = 50f;

    private int targetScore1;
    private int targetScore2;
    private int maxScore;

    void Start()
    {
        targetScore1 = player1Score.currentScore;
        targetScore2 = player2Score.currentScore;

        // Determina el puntaje más alto para usarlo como referencia
        maxScore = Mathf.Max(targetScore1, targetScore2, 1); // Evita división por 0

        StartCoroutine(FillBars());
    }

    IEnumerator FillBars()
    {
        float currentHeight1 = minBarHeight;
        float currentHeight2 = minBarHeight;
        int displayScore1 = 0;
        int displayScore2 = 0;

        float targetHeight1 = Mathf.Lerp(minBarHeight, maxBarHeight, (float)targetScore1 / maxScore);
        float targetHeight2 = Mathf.Lerp(minBarHeight, maxBarHeight, (float)targetScore2 / maxScore);

        while (displayScore1 < targetScore1 || displayScore2 < targetScore2)
        {
            if (displayScore1 < targetScore1)
            {
                displayScore1 = Mathf.Min(displayScore1 + Mathf.CeilToInt(fillSpeed * Time.unscaledDeltaTime * targetScore1), targetScore1);
                float height1 = Mathf.Lerp(minBarHeight, maxBarHeight, (float)displayScore1 / maxScore);
                player1Bar.sizeDelta = new Vector2(player1Bar.sizeDelta.x, height1);
                player1Text.text = displayScore1.ToString();
            }

            if (displayScore2 < targetScore2)
            {
                displayScore2 = Mathf.Min(displayScore2 + Mathf.CeilToInt(fillSpeed * Time.unscaledDeltaTime * targetScore2), targetScore2);
                float height2 = Mathf.Lerp(minBarHeight, maxBarHeight, (float)displayScore2 / maxScore);
                player2Bar.sizeDelta = new Vector2(player2Bar.sizeDelta.x, height2);
                player2Text.text = displayScore2.ToString();
            }

            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.5f);
        ShowResult();
    }

    void ShowResult()
    {
        if (targetScore1 > targetScore2)
            resultText.text = "Jugador 1 Gana";
        else if (targetScore2 > targetScore1)
            resultText.text = "Jugador 2 Gana";
        else
            resultText.text = "Empate";
    }
}
