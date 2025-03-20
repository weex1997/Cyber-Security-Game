using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoundType
{
    Walk,
    Lose,
    Win,
    Buy,
    Coins,
    Buttons,
    iPad,
    Devices,
    Wrong,
    Correct,
    Shoot,
    PickUp,
    Damage,
    LoseHeart,
    OpenDoor,
    MonesterLaugh,
    Yay
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] AudioClip[] sounds;
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundList[] soundLists;


    // Audio players components.
    public AudioSource audioSource;


    // Singleton instance.
    public static SoundManager instance;

    // Initialize the singleton instance.
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
         if (instance != this)
            Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        {
            Array.Resize(ref soundLists, names.Length);
            for (int i = 0; i < soundLists.Length; i++)
            {
                soundLists[i].name = names[i];
            }
        }
    }
#endif
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.loop = false;
        AudioClip[] clip = instance.soundLists[(int)sound].Sounds;
        AudioClip randomClip = clip[Random.Range(0, clip.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
    }
    public static void PlaySoundLoop(SoundType sound, float volume = 1)
    {
        AudioClip[] clip = instance.soundLists[(int)sound].Sounds;
        AudioClip randomClip = clip[Random.Range(0, clip.Length)];
        instance.audioSource.loop = true;
        instance.audioSource.volume = volume;
        instance.audioSource.clip = randomClip;
        instance.audioSource.Play();
    }
    public static void StopSound()
    {
        instance.audioSource.Stop();
    }

}
