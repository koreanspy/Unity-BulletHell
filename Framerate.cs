using UnityEngine;

public class Framerate : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private float fps = 0.0f;
    private float updateInterval = 0.1f; // Update every 0.5 seconds
    private float timeSinceLastUpdate = 0.0f;

    void Update()
    {
        // Accumulate the deltaTime for smoothing
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        timeSinceLastUpdate += Time.deltaTime;

        // Only update the FPS value when the interval has passed
        if (timeSinceLastUpdate >= updateInterval)
        {
            fps = 1.0f / deltaTime;
            timeSinceLastUpdate = 0.0f;
        }
    }

    void OnGUI()
    {
        // Set the style for the label
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(10, 10, 200, 20);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        // Display the framerate
        string text = string.Format("{0:0.} FPS", fps);
        GUI.Label(rect, text, style);
    }
}
