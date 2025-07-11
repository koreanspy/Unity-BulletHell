using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public UnityEvent MusicChange;

    private EventInstance currentMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        //currentMusic = AudioManager.Instance.CreateInstance(FMODEvents.Instance.MarisaTheme);
        //currentMusic.start();
    }

    public void ChangeMusic()
    {

    }
}
