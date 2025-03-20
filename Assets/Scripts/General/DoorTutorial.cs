using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTutorial : MonoBehaviour
{
    public GameTutorial gameTutorial;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameTutorial.TriggerTutorial();
        }

    }
}
