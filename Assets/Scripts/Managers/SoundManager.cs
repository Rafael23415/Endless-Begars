using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private Slider slider;

    [SerializeField] private List<AudioSource> audioSources = new();

    [SerializeField] private AudioSource backgroundAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddAudioSource(AudioSource audioSource)
    {
        audioSources.Add(audioSource);
    }

    public void ChangeVolume()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = slider.value;
        }
        backgroundAudioSource.volume = slider.value / 4;
    }
}
