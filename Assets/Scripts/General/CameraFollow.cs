using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public bool stopFollow = false;
    // Update is called once per frame
    void Update()
    {
        if (!stopFollow)
            transform.position = player.transform.position + new Vector3(5.1f, 1.46f, -10);
    }

}
