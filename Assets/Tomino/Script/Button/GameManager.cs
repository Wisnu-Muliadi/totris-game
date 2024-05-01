using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add other audio-related functionality here
    public void SearchAudioPlayers()
    {
        //audioSource = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }
}