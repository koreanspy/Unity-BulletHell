using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowExpandTest : MonoBehaviour
{
    public int wantedResolution = 1500;
    float expandSpeed = 50f; // Adjust speed as necessary
    private int currentResolution;

    void Start()
    {
        
        Screen.SetResolution(1280, 960, FullScreenMode.Windowed);
        currentResolution = Screen.width;
        wantedResolution = 1500;
    }
    
    void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            StartCoroutine(ExpandWindow());
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            StartCoroutine(ShrinkWindow());
        }
    }

    void FixedUpdate()
    {
        
    }
    

    private IEnumerator ExpandWindow()
    {
        while (currentResolution < wantedResolution)
        {
            if (currentResolution >= wantedResolution)
            {
                StopCoroutine(ExpandWindow());
            }
            currentResolution += (int)(750 * Time.deltaTime);
            
            Screen.SetResolution(currentResolution, Screen.height, FullScreenMode.Windowed);

            Debug.Log("Current Resolution: " + currentResolution);

            yield return null; // Wait for the next frame
        }

        Debug.Log("Resolution reached: " + currentResolution);
    }
    
    private IEnumerator ShrinkWindow()
    {
        while (currentResolution > 1280)
        {
            if (currentResolution <= 1280)
            {
                StopCoroutine(ShrinkWindow());
            }
            currentResolution -= (int)(750 * Time.deltaTime);
            
            Screen.SetResolution(currentResolution, Screen.height, FullScreenMode.Windowed);

            Debug.Log("Current Resolution: " + currentResolution);

            yield return null; // Wait for the next frame
        }

        Debug.Log("Resolution reached: " + currentResolution);
    }
}
