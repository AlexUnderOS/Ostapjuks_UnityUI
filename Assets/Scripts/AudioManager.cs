using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backMusicSource;
    public AudioSource actionEffectSource;
    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void onClickPlayAudio(AudioClip clip)
    {
        actionEffectSource.clip = clip;
        actionEffectSource.Play();
    }
}
