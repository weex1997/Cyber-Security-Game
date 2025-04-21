
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage2Rules : MonoBehaviour
{
    public DialogueTriggers dialogueTriggers;
    public GunShots gunShots;
    public Spawner spawner;
    bool stopDialogue = false;
    public GameObject playerEquipment;
    public GameObject gun;
    public GameObject wall;
    public int collectEquipment = 0;

    void Start()
    {
        GameManager.Instance.TimerForLose = false;
    }

    void Update()
    {

        if (dialogueTriggers.clickNum == 1 && !stopDialogue)
        {
            dialogueTriggers.isThereCondtions = true;
            playerEquipment.SetActive(true);
            stopDialogue = true;
        }
        if (collectEquipment == 2)
        {
            dialogueTriggers.isThereCondtions = false;
            collectEquipment = 0;
        }
        if (dialogueTriggers == null && stopDialogue)
        {
            gunShots.start = true;
            spawner.start = true;
            stopDialogue = false;
        }

        // Skip if clicking a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Gun")
                {
                    gun.SetActive(true);
                    collectEquipment++;
                    //sound
                    SoundManager.PlaySound(SoundType.PickUp);
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.tag == "Wall")
                {
                    wall.SetActive(true);
                    collectEquipment++;
                    //sound
                    SoundManager.PlaySound(SoundType.PickUp);
                    Destroy(hit.collider.gameObject);
                }

            }
        }

    }

}
