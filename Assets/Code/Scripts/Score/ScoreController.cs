using UnityEngine;
using TMPro;
using static UnityEditor.AddressableAssets.Build.Layout.BuildLayout;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        
        UpdateScoreText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bubble"))
        {
            ScoreGiver bubble = collision.gameObject.GetComponent<ScoreGiver>();
            if (bubble != null)
            {
                currentScore += bubble.points;
                UpdateScoreText();
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "1P - " + currentScore.ToString();
    }
}
