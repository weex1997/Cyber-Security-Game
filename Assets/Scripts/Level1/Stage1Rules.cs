using UnityEngine;

public class Stage1Rules : MonoBehaviour
{
    bool openOnes = false;
    public GameObject lettersPanel;
    public GameObject numbersPanel;
    public GameObject symbelsPanel;
    public GameObject finalComputerPanel;
    public GameObject iPad;
    public GameObject CarriableiPad;
    int computerCount = 0;
    public GameObject Robot2;
    public GameObject hearts;
    public static Stage1Rules Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (GameManager.Instance.dialogueCount == 2 && !openOnes)
        {
            openOnes = false;
            finalComputerPanel.SetActive(true);
            hearts.SetActive(true);
            iPad.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {

                if (hit.collider.tag == "iPad")
                {
                    CarriableiPad.SetActive(true);
                    Destroy(hit.collider.gameObject);
                    //sound
                    SoundManager.PlaySound(SoundType.iPad);
                }
                if (hit.collider.tag == "LettersBox")
                {

                    lettersPanel.SetActive(true);

                    iPad.SetActive(true);
                    //hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    computerCount++;

                    //sound
                    SoundManager.PlaySound(SoundType.Devices);
                }
                if (hit.collider.tag == "NumbersBox")
                {
                    numbersPanel.SetActive(true);

                    iPad.SetActive(true);
                    //hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    computerCount++;

                    //sound
                    SoundManager.PlaySound(SoundType.Devices);
                }
                if (hit.collider.tag == "SymbelsBox")
                {


                    symbelsPanel.SetActive(true);

                    iPad.SetActive(true);
                    //hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    computerCount++;

                    //sound
                    SoundManager.PlaySound(SoundType.Devices);
                }
                if (computerCount == 3)
                {
                    Robot2.SetActive(true);
                    computerCount++;
                }

            }
        }
    }

    public void DoneButton()
    {
        numbersPanel.SetActive(false);
        lettersPanel.SetActive(false);
        symbelsPanel.SetActive(false);
        iPad.SetActive(false);

        //sound
        SoundManager.PlaySound(SoundType.Buttons);
    }

    public void cheackPassword()
    {
        if (finalComputerPanel.activeInHierarchy)
            finalComputerPanel.GetComponent<PasswordComputerPanel>().CheckPasword();
    }

}
