using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsSystem : MonoBehaviour
{
    public List<GameObject> Doors = new List<GameObject>();
    public Sprite OpenDoor;
    public int currentStage;
    public int totalStages = 3;
    public FinalDoor finalDoor;
    public Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        //get current player stage
        if (PlayerPrefs.HasKey("PlayerStage1"))
        {
            if (PlayerPrefs.HasKey("PlayerStage2"))
            {
                if (PlayerPrefs.HasKey("PlayerStage3"))
                {
                    currentStage = 3;
                }
                else
                    currentStage = 2;
            }
            else
                currentStage = 1;
        }
        else
            currentStage = 0;


        for (int i = 0; i <= currentStage; i++)
        {
            if (i < totalStages)
            {
                Doors[i].gameObject.GetComponent<SpriteRenderer>().sprite = OpenDoor;
                Doors[i].tag = "DoorOpen";
            }
            else
            {
                Debug.Log("open the final door");
                finalDoor.itsfinal = true;
                finalDoor.StartFinalDoor();
            }
        }
        if (currentStage < totalStages && PlayerPrefs.HasKey("WalkTutorial"))
        {
            Vector2 vector2 = player.position;
            vector2.x = Doors[currentStage].transform.position.x;
            player.position = vector2;
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
