using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Si tu utilises Text classique
    // public TMP_Text scoreText; // Si tu utilises TextMeshPro (n'oublie pas d'importer TMPro)

    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void Update()
    {
        AddScore(1);
    }
}
