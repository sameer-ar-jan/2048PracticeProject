

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

[TestFixture]
public class GameManagerTests
{
    private GameManager _gameManager;
    private InitialState _initialState;
    private GameObject check;

    [SetUp]
    public void SetUp()
    {

        check = GameObject.Find("GameManager");
        Debug.Log("GameManager object found: " + (check != null));

        //_initialState = ScriptableObject.CreateInstance<InitialState>(); // Create ScriptableObject

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



        //_gameManager = new GameManager(); // Still needed

        //_gameManager.board = GameObject.Find("TileBoard").GetComponent<TileBoard>();
        // Set initial values using the public method
        _gameManager.SetInitialState(_initialState.initialScore, _initialState.gameOverAlpha, _initialState.gameOverInteractable);
    }


    [Test]
    public void NewGame_ResetsScoreAndHighScoreText()
    {
        Debug.Log($"Score after NewGame: ");
        //Debug.Log($"Score after NewGame: {_gameManager.score}");
        //Debug.Log($"Score Text after NewGame: {_gameManager.scoreText.text}");

        _gameManager.NewGame();

        Debug.Log($"Score after NewGame: {_gameManager.score}");
        Debug.Log($"Score Text after NewGame: {_gameManager.scoreText.text}");

        Assert.AreEqual(0, _gameManager.score);
        Assert.AreEqual("0", _gameManager.scoreText.text);
    }

    //[Test]
    //public void NewGame_HidesGameOverMenuAndClearsBoard()
    //{
    //    _gameManager.NewGame();

    //    Assert.AreEqual(0f, _gameManager.gameOver.alpha);
    //    Assert.IsFalse(_gameManager.gameOver.interactable);
    //    // Mock TileBoard to verify ClearBoard is called
    //}


    //[Test]
    //public void GameOver_ShowsGameOverMenuAndDisablesBoard()
    //{
    //    _gameManager.GameOver();

    //    Assert.IsTrue(_gameManager.gameOver.interactable);
    //    // Mock TileBoard to verify enabled is set to false
    //}


    //[Test]
    //public void IncreaseScore_UpdatesScoreAndText()
    //{
    //    int points = 20;
    //    _gameManager.IncreaseScore(points);

    //    Assert.AreEqual(points, _gameManager.score);
    //    Assert.AreEqual(points.ToString(), _gameManager.scoreText.text);
    //}

}




