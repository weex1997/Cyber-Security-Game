using UnityEngine;
using UnityEngine.Video;

public class VideoEndDetector : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    [SerializeField] PlayerDataPanel playerDataPanel;
    [SerializeField] FinalDoor finalDoor;
    public AudioSource musicAudioSource;
    float musicVolum;

    void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += OnVideoEnd;
        musicVolum = musicAudioSource.volume;
        musicAudioSource.volume = 0.15f;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video finished playing!");
        if (playerDataPanel != null)
            playerDataPanel.VideoIsFinished();
        if (finalDoor != null)
            finalDoor.certificate.SetActive(true);
        gameObject.SetActive(false);
        musicAudioSource.volume = musicVolum;
    }

    void OnDestroy()
    {
        // Clean up the event subscription
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoEnd;
    }
}