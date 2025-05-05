
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    public QuestionsSystem questionsSystem;
    public bool itsfinal = false;
    public Transform finalDoorPostion;
    public Transform player;
    public GameObject robot;

    public GameObject loseRobot;
    public GameObject winRobot;
    public GameObject[] locksObjects;
    public GameObject certificate;
    public GameObject video;
    public float totalSuccessPercentage;
    float passLock;
    float shieldLock;
    float cardLock;
    bool startOne = false;
    // Start is called before the first frame update
    public void StartFinalDoor()
    {
        player.position = finalDoorPostion.position;
        robot.SetActive(true);
        CheckDoorsLock();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && itsfinal)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null && !questionsSystem.questionActive)
            {
                if (hit.collider.tag == "PasswordCategory")
                {
                    //sound
                    SoundManager.PlaySound(SoundType.Devices);

                    questionsSystem.category = hit.collider.tag;
                    questionsSystem.gameObject.SetActive(true);
                    questionsSystem.Reset();
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    questionsSystem.questionActive = true;

                }
                if (hit.collider.tag == "ShieldCategory")
                {
                    //sound
                    SoundManager.PlaySound(SoundType.Devices);

                    questionsSystem.category = hit.collider.tag;
                    questionsSystem.gameObject.SetActive(true);
                    questionsSystem.Reset();
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    questionsSystem.questionActive = true;

                }
                if (hit.collider.tag == "CardCategory")
                {
                    //sound
                    SoundManager.PlaySound(SoundType.Devices);

                    questionsSystem.category = hit.collider.tag;
                    questionsSystem.gameObject.SetActive(true);
                    questionsSystem.Reset();
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    questionsSystem.questionActive = true;

                }

            }
        }
        if (winRobot == null && !startOne)
        {
            video.SetActive(true);
            startOne = true;
        }
        if (loseRobot == null && !startOne)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
            startOne = true;
        }

    }
    public void CheckDoorsLock()
    {
        foreach (GameObject doorLcok in locksObjects)
        {
            passLock = PlayerPrefs.GetFloat("PasswordCategory");
            shieldLock = PlayerPrefs.GetFloat("ShieldCategory");
            cardLock = PlayerPrefs.GetFloat("CardCategory");

            if (doorLcok.tag == "PasswordCategory")
                if (passLock > 60)
                {
                    doorLcok.SetActive(false);
                }

            if (doorLcok.tag == "ShieldCategory")
                if (shieldLock > 60)
                {
                    doorLcok.SetActive(false);
                }

            if (doorLcok.tag == "CardCategory")
                if (cardLock > 60)
                {
                    doorLcok.SetActive(false);
                }

        }

        EndTheGame();
    }
    void EndTheGame()
    {
        totalSuccessPercentage = (passLock + shieldLock + cardLock) / 3;
        PlayerPrefs.SetInt("TotalSuccessPercentage", (int)totalSuccessPercentage);

        if (PlayerPrefs.HasKey("PasswordCategory") &&
          PlayerPrefs.HasKey("ShieldCategory") &&
          PlayerPrefs.HasKey("CardCategory") &&
          totalSuccessPercentage > 60)
        {
            winRobot.SetActive(true);
            if (robot != null)
                robot.SetActive(false);
            PlayerData.Instance.SaveDataToTheServier();
        }
        else if (PlayerPrefs.HasKey("PasswordCategory") &&
          PlayerPrefs.HasKey("ShieldCategory") &&
          PlayerPrefs.HasKey("CardCategory"))
        {
            loseRobot.SetActive(true);
            if (robot != null)
                robot.SetActive(false);
        }


    }

}
