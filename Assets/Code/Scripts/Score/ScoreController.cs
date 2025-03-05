using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isTwoPlayer = false;

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
        string playerPrefix = isTwoPlayer ? "2P - " : "1P - ";
        scoreText.text = playerPrefix + currentScore.ToString();
    }
}
