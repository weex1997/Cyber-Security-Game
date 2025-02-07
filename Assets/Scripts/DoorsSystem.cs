using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsSystem : MonoBehaviour
{
    public List<GameObject> Doors = new List<GameObject>();
    public Sprite OpenDoor;
    public int currentStage;
    // Start is called before the first frame update
    void Start()
    {
        currentStage = PlayerPrefs.GetInt("PlayerStage");
        for (int i = 0; i <= currentStage; i++)
        {
            Doors[i].gameObject.GetComponent<SpriteRenderer>().sprite = OpenDoor;
            Doors[i].tag = "DoorOpen";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "DoorOpen")
                {
                    SceneManager.LoadScene(hit.collider.gameObject.name);
                    Debug.Log("hit open door");
                }
                if (hit.collider.tag == "DoorClose")
                {
                    Debug.Log("the dool close need to finish pervuis door");
                }
            }
        }
    }


}
