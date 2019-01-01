using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    #region Singleton

    public static ScoreController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ScoreController found!");
        }
        instance = this;
    }

    #endregion Singleton

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.SetText($"Score: {ScoreModel.Score}");
    }

    public void AddScore(int points)
    {
        ScoreModel.Score += points;

        DisplayScore();
    }

    public void SetRestartScore()
    {
        ScoreModel.RestartScore = ScoreModel.Score;
    }

    public void ResetScore()
    {
        ScoreModel.Score = ScoreModel.RestartScore;
    }

}