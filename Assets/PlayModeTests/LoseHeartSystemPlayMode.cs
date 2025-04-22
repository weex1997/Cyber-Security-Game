using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LoseHeartSystemPlayMode
{
    [UnityTest]
    public IEnumerator GameManger_LoseHeart()
    {

        // Arrange
        yield return SceneManager.LoadSceneAsync("1");

        GameManager gameManager = Object.FindObjectOfType<GameManager>();

        // Act
        gameManager.LoseHeart(3);

        // Assert
        Assert.IsTrue(gameManager.itsLose);

    }
}
