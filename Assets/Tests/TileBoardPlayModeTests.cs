using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;

public class TileBoardTests
{
    private Mock<GameManager> mockGameManager;
    private Mock<TileGrid> mockGrid;
    private TileBoard tileBoard;
    private List<TileState> mockTileStates;
    private Tile mockTilePrefab;

    [SetUp]
    public void Setup()
    {
        mockGameManager = new Mock<GameManager>();
        mockGrid = new Mock<TileGrid>();
        mockTileStates = new List<TileState>();
        mockTilePrefab = new Mock<Tile>().Object;

        tileBoard = new TileBoard();
        tileBoard.gamemanager = mockGameManager.Object;
        tileBoard.grid = mockGrid.Object;
        tileBoard.tileStates = mockTileStates.ToArray();
        tileBoard.tilePrefab = mockTilePrefab;
    }

    [Test]
    public void CreateTile_ShouldInstantiateTile_AndAddToTilesList()
    {
        // Arrange
        mockGrid.Setup(g => g.GetRandomEmptyCell()).Returns(new TileCell());

        // Act
        tileBoard.CreateTile();

        // Assert
        mockGrid.Verify(g => g.GetRandomEmptyCell(), Times.Once);
        mockTilePrefab.Verify(t => t.Instantiate(It.IsAny<Transform>()), Times.Once);
        Assert.AreEqual(1, tileBoard.tiles.Count);
    }

    [Test]
    public void ClearBoard_ShouldDestroyAllTiles_AndClearList()
    {
        // Arrange
        var mockTile1 = new Mock<Tile>();
        var mockTile2 = new Mock<Tile>();
        tileBoard.tiles.Add(mockTile1.Object);
        tileBoard.tiles.Add(mockTile2.Object);

        // Act
        tileBoard.ClearBoard();

        // Assert
        mockTile1.Verify(t => t.Destroy(It.IsAny<GameObject>()), Times.Once);
        mockTile2.Verify(t => t.Destroy(It.IsAny<GameObject>()), Times.Once);
        Assert.IsEmpty(tileBoard.tiles);
    }

    [Test]
    public void MoveTiles_Up_ShouldMoveOccupiedTiles_AndStartCoroutine()
    {
        // Arrange
        mockGrid.Setup(g => g.width).Returns(4);
        mockGrid.Setup(g => g.height).Returns(4);
        var mockCell1 = new Mock<TileCell>();
        var mockCell2 = new Mock<TileCell>();
        var mockTile = new Mock<Tile>();
        mockCell1.Setup(c => c.occupied).Returns(true);
        mockCell1.Setup(c => c.tile).Returns(mockTile.Object);
        mockGrid.SetupSequence(g => g.GetCell(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(mockCell1.Object)
            .Returns(new Mock<TileCell>().Object);

        // Act
        tileBoard.MoveTiles(Vector2Int.up, 0, 1, 1, 1);

        // Assert
        mockTile.Verify(t => t.MoveTo(It.IsAny<TileCell>()), Times.Once);
        mockGameManager.Verify(m => m.StartCoroutine(It.IsAny<IEnumerator>()), Times.Once);
    }

    [Test]
    public void MoveTiles_Up_ShouldNotStartCoroutine_IfNoTilesMoved()
    {
        // Arrange
        mockGrid.Setup(g => g.width).Returns(4);
        mockGrid.Setup(g => g.height).Returns(4);
        mockGrid.SetupSequence(g => g.GetCell(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(new Mock<TileCell>().Object)
            .Returns(new Mock<TileCell>().Object);

        // Act
        tileBoard.MoveTiles(Vector2Int.up, 0, 1, 1, 1);

        // Assert
        mockGameManager.Verify(m => m.StartCoroutine(It.IsAny < IEnumerator


//using NUnit.Framework;
//using UnityEngine;
//using UnityEngine.TestTools;
//using System.Collections;

//[TestFixture]
//public class GameManagerTests
//{
//    private GameManager _gameManager;
//    private InitialState _initialState;
//    private GameObject check;

//    [SetUp]
//    public void SetUp()
//    {

//        check = GameObject.Find("GameManager");
//        Debug.Log("GameManager object found: " + (check != null));

//        //_initialState = ScriptableObject.CreateInstance<InitialState>(); // Create ScriptableObject

//        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



//        //_gameManager = new GameManager(); // Still needed

//        //_gameManager.board = GameObject.Find("TileBoard").GetComponent<TileBoard>();
//        // Set initial values using the public method
//        _gameManager.SetInitialState(_initialState.initialScore, _initialState.gameOverAlpha, _initialState.gameOverInteractable);
//    }


//    [Test]
//    public void NewGame_ResetsScoreAndHighScoreText()
//    {
//        Debug.Log($"Score after NewGame: ");
//        //Debug.Log($"Score after NewGame: {_gameManager.score}");
//        //Debug.Log($"Score Text after NewGame: {_gameManager.scoreText.text}");

//        _gameManager.NewGame();

//        Debug.Log($"Score after NewGame: {_gameManager.score}");
//        Debug.Log($"Score Text after NewGame: {_gameManager.scoreText.text}");

//        Assert.AreEqual(0, _gameManager.score);
//        Assert.AreEqual("0", _gameManager.scoreText.text);
//    }

//    //[Test]
//    //public void NewGame_HidesGameOverMenuAndClearsBoard()
//    //{
//    //    _gameManager.NewGame();

//    //    Assert.AreEqual(0f, _gameManager.gameOver.alpha);
//    //    Assert.IsFalse(_gameManager.gameOver.interactable);
//    //    // Mock TileBoard to verify ClearBoard is called
//    //}


//    //[Test]
//    //public void GameOver_ShowsGameOverMenuAndDisablesBoard()
//    //{
//    //    _gameManager.GameOver();

//    //    Assert.IsTrue(_gameManager.gameOver.interactable);
//    //    // Mock TileBoard to verify enabled is set to false
//    //}


//    //[Test]
//    //public void IncreaseScore_UpdatesScoreAndText()
//    //{
//    //    int points = 20;
//    //    _gameManager.IncreaseScore(points);

//    //    Assert.AreEqual(points, _gameManager.score);
//    //    Assert.AreEqual(points.ToString(), _gameManager.scoreText.text);
//    //}

//}




