using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

[TestFixture]
public class TileBoardPlayModeTests
{
    [UnityTest]
    public IEnumerator TestSomeRuntimeLogic()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<Rigidbody>();

        // Act
        yield return new WaitForSeconds(1.0f);

        // Assert
        Assert.IsNotNull(gameObject.GetComponent<Rigidbody>());
    }
}

