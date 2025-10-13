using UnityEngine;

public class ESQ : MonoBehaviour
{
    public float holdDuration = 2f; // Seconds to hold before quitting
    private float holdTime = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            holdTime += Time.deltaTime;

            if (holdTime >= holdDuration)
            {
                Debug.Log("Quitting game...");
                Application.Quit();

                // If you're testing in the editor, this won't quit the editor.
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
        else
        {
            holdTime = 0f; // Reset if key is released
        }
    }
}

