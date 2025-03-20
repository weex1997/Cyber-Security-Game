using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerControlButtons : MonoBehaviour
{
    public float speed;
    bool move = false;
    bool isRight = false;
    Rigidbody2D rb;
    public CameraFollow cameraFollow;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (move == true)
        {
            if (isRight == true)
            {
                // float xforce = speed * Time.deltaTime;
                // Vector2 force = new Vector2(xforce, rb.li.y);
                rb.MovePosition(transform.position + Vector3.left * -speed * Time.deltaTime);

            }

            else
                rb.MovePosition(transform.position + Vector3.left * speed * Time.deltaTime);

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
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "StopWall")
            cameraFollow.stopFollow = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "StopWall")
            cameraFollow.stopFollow = false;
    }
    public void PlaySound()
    {
        //sound
        SoundManager.PlaySoundLoop(SoundType.Walk, 0.09f);
    }
    public void StopSound()
    {
        //sound
        SoundManager.StopSound();
    }
}
