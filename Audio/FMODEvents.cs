using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    [field: SerializeField] public EventReference ShotTwinkle { get; private set; }


    [field: SerializeField] public EventReference MarisaTheme { get; private set; }

    public static FMODEvents Instance {  get; private set; }

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
}
