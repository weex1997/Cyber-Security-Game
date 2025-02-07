using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerControlButtons : MonoBehaviour
{
    bool move = false;
    bool isRight = false;

    void Update()
    {
        if (move == true)
        {
            if (isRight == true)
                gameObject.GetComponent<Transform>().position += transform.right * 5 * Time.deltaTime;
            else
                gameObject.GetComponent<Transform>().position += transform.right * -5 * Time.deltaTime;

        }
    }
    public void moveButtons(bool _move)
    {
        move = _move;
    }
    public void RightOrLeftButtons(bool _isRight)
    {
        isRight = _isRight;
    }

}
