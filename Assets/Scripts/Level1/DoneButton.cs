using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneButton : MonoBehaviour
{
    public Transform passwordParent;
    bool stop = false;

    // Update is called once per frame
    void Update()
    {

        //check if the computer object has any children,
        // which means the player misses some Character,
        // so do not interactable with the done button 
        // must all children be on the iPad

        if (!stop && passwordParent.childCount <= 3)
        {
            gameObject.GetComponent<Button>().interactable = true;
            stop = true;
        }
        if (passwordParent.childCount > 3 && stop)
        {
            gameObject.GetComponent<Button>().interactable = false;
            stop = false;
        }
    }
}
