using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;

using System.Collections;
using UnityEngine;

public class MyFirstTest
{   //Important! If your test file is inside a folder that contains an .asmdef file, please make sure that the assembly definition references NUnit.
    public AltDriver altDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver = new AltDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }

    [Test]
    public void Test()
    {
        
        altDriver.LoadScene("MainMenu");
        //altDriver.LoadScene("2048");
        var altObject = altDriver.FindObject(By.NAME, "Play");
        altDriver.FindObject(By.NAME, "Play").Tap();
        var panelElement = altDriver.WaitForObject(By.NAME, "Board");
        Assert.NotNull(altObject);
        Assert.IsTrue(panelElement.enabled);
    }


    //[Test]
    //public void TestTileMovement()
    //{
    //    altDriver.LoadScene("2048"); // Ensure the correct scene is loaded

    //    // Create a new tile at the initial state
    //    altDriver.CallStaticMethod<System.Object>("TileBoard", "CreateTile","MyScriptsAssembly", new[] {"" });

    //    // Get the initial position of the tile
    //    AltUnityObject tile = altDriver.FindObject(By.NAME, "Tile");
    //    Vector2 initialPosition = new Vector2(tile.x, tile.y);

    //    // Move tile up
    //    altDriver.PressKey(AltUnityKeyCode.W);
    //    altDriver.Wait(1);
    //    Vector2 newPosition = new Vector2(tile.x, tile.y);
    //    Assert.AreNotEqual(initialPosition, newPosition, "Tile did not move up.");

    //    initialPosition = newPosition;

    //    // Move tile down
    //    altDriver.PressKey(AltUnityKeyCode.S);
    //    altDriver.Wait(1);
    //    newPosition = new Vector2(tile.x, tile.y);
    //    Assert.AreNotEqual(initialPosition, newPosition, "Tile did not move down.");

    //    initialPosition = newPosition;

    //    // Move tile left
    //    altDriver.PressKey(AltUnityKeyCode.A);
    //    altDriver.Wait(1);
    //    newPosition = new Vector2(tile.x, tile.y);
    //    Assert.AreNotEqual(initialPosition, newPosition, "Tile did not move left.");

    //    initialPosition = newPosition;

    //    // Move tile right
    //    altDriver.PressKey(AltUnityKeyCode.D);
    //    altDriver.Wait(1);
    //    newPosition = new Vector2(tile.x, tile.y);
    //    Assert.AreNotEqual(initialPosition, newPosition, "Tile did not move right.");
    //}

}