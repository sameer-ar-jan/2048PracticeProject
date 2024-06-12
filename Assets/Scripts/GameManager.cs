using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;

    public int score;

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        if (HighScoreText == null)
        {
            Debug.LogError("HighScoreText is null in NewGame");
            return;
        }

        if (gameOver == null)
        {
            Debug.LogError("gameOver is null in NewGame");
            return;
        }

        if (board == null)
        {
            Debug.LogError("board is null in NewGame");
            return;
        }

        score = 0;
        HighScoreText.text = LoadHighScore().ToString();

        gameOver.alpha = 0f;
        gameOver.interactable = false;

        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        if (gameOver == null)
        {
            Debug.LogError("gameOver is null in GameOver");
            return;
        }

        board.enabled = false;
        gameOver.interactable = true;
        StartCoroutine(Fade(gameOver, 1f, 1f));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();

        SaveHighScore();
    }

    private void SaveHighScore()
    {
        int highScore = LoadHighScore();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    private int LoadHighScore()
    {
        return PlayerPrefs.GetInt("highScore", 0);
    }

    public void SetInitialState(int initialScore, float gameOverAlpha, bool gameOverInteractable)
    {
        if (scoreText == null)
        {
            Debug.LogError("scoreText is null in SetInitialState");
            return;
        }

        if (HighScoreText == null)
        {
            Debug.LogError("HighScoreText is null in SetInitialState");
            return;
        }

        scoreText.text = initialScore.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();

        this.gameOver.alpha = gameOverAlpha;
        this.gameOver.interactable = gameOverInteractable;
    }
}








//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class GameManager : MonoBehaviour
//{
//    public TileBoard board;
//    public CanvasGroup gameOver;
//    public TextMeshProUGUI scoreText;
//    public TextMeshProUGUI HighScoreText;

//    public int score;
//    private float gameOverAlpha;
//    private bool gameOverInteractable;

//    private void Start()
//    {
//        //SetInitialState(0, 0f, false); // Example initial state call (adjust values as needed)
//        NewGame();
//    }

//    public void NewGame()
//    {
//        score = 0;
//        HighScoreText.text = LoadHighScore().ToString();

//        gameOver.alpha = 0f;
//        gameOver.interactable = false;

//        board.ClearBoard();
//        board.CreateTile();
//        board.CreateTile();
//        board.enabled = true;
//    }

//    public void GameOver()
//    {
//        board.enabled = false;
//        gameOver.interactable = true;
//        StartCoroutine(Fade(gameOver, 1f, 1f));
//    }

//    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
//    {
//        yield return new WaitForSeconds(delay);

//        float elapsed = 0f;
//        float duration = 0.5f;
//        float from = canvasGroup.alpha;

//        while (elapsed < duration)
//        {
//            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
//            elapsed += Time.deltaTime;
//            yield return null;
//        }

//        canvasGroup.alpha = to;
//    }

//    public void IncreaseScore(int points)
//    {
//        SetScore(score + points);
//    }

//    private void SetScore(int score)
//    {
//        this.score = score;
//        scoreText.text = score.ToString();

//        SaveHighScore();
//    }

//    private void SaveHighScore()
//    {
//        int highScore = LoadHighScore();

//        if (score > highScore)
//        {
//            PlayerPrefs.SetInt("highScore", score);
//        }
//    }

//    private int LoadHighScore()
//    {
//        return PlayerPrefs.GetInt("highScore", 0);
//    }

//    public void SetInitialState(int initialScore, float gameOverAlpha, bool gameOverInteractable)
//    {
//        // Ensure scoreText and highScoreText are not null before accessing them
//        //if (scoreText == null)
//        //{
//        //    Debug.LogError("scoreText is null");
//        //}
//        //else
//        //{
//            scoreText.text = initialScore.ToString();
//        //}

//        //if (HighScoreText == null)
//        //{
//        //    Debug.LogError("HighScoreText is null");
//        //}
//        //else
//        //{
//            HighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
//        //}


//        // Additional code to set gameOverAlpha and gameOverInteractable
//    }
//}
