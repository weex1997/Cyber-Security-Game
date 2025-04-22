using NUnit.Framework;
using UnityEngine;

public class LoseHeartSystemEditMode
{
    [Test]
    public void GameManger_LoseHeart()
    {

        // Arrange
        var go = new GameObject("GameManager");
        var gameManager = go.AddComponent<GameManager>();

        // Act
        gameManager.LoseHeart(3);

        // Assert
        Assert.IsTrue(gameManager.itsLose);
    }

}
