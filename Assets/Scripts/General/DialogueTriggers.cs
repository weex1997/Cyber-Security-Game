using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogueTriggers : MonoBehaviour
{
    public List<string> DialogueString = new List<string>();
    public GameObject DialogueBox;
    public RTLTextMeshPro DialogueText;
    public int clickNum = 0;
    bool start = false;
    public bool isThereCondtions = false;
    public bool itsDialogue;
    public bool isThereVoice;


    AudioSource dialogueVoicesAudioSource;
    [SerializeField] List<AudioClip> dialogeClips = new List<AudioClip>();
    [SerializeField] AudioSource mudicAduioSource;
    float musicVolum;

    void Start()
    {
        dialogueVoicesAudioSource = gameObject.GetComponent<AudioSource>();

        if (!itsDialogue)
        {
            Time.timeScale = 0;
            DialogueBox.SetActive(true);
            DialogueText.text = DialogueString[clickNum];
            if (isThereVoice)
            {
                PlayVoice(dialogeClips[clickNum], 1);
                musicVolum = mudicAduioSource.volume;
                mudicAduioSource.volume = 0.15f;
            }
            start = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            DialogueBox.SetActive(true);
            DialogueText.text = DialogueString[clickNum];
            if (isThereVoice)
            {
                PlayVoice(dialogeClips[clickNum], 1);
                musicVolum = mudicAduioSource.volume;
                mudicAduioSource.volume = 0.15f;
            }
            start = true;
            //SetAllCollidersInteract(false);
        }

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && start == true && !isThereCondtions)
        {
            clickNum++;

            if (clickNum < DialogueString.Count)
            {
                DialogueText.text = DialogueString[clickNum];
                if (isThereVoice)
                {
                    PlayVoice(dialogeClips[clickNum], 1);
                    musicVolum = mudicAduioSource.volume;
                    mudicAduioSource.volume = 0.15f;
                }
            }
            else
            {
                start = false;
                Time.timeScale = 1;
                if (GameManager.Instance != null)
                    GameManager.Instance.dialogueCount++;

                //SetAllCollidersInteract(true);

                Destroy(gameObject);
            }

        }
    }

    void PlayVoice(AudioClip sound, float volume = 1)
    {
        dialogueVoicesAudioSource.volume = volume;
        dialogueVoicesAudioSource.clip = sound;
        dialogueVoicesAudioSource.Play();
    }
    void OnDestroy()
    {
        if (mudicAduioSource != null)
            mudicAduioSource.volume = musicVolum;
    }
}
