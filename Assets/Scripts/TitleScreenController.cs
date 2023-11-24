using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public string SceneAudrey;
    public float holdDuration = 2f; // Adjust the hold duration as needed

    private bool isSpaceBarHeld = false;
    private float spaceBarHoldStartTime;

    private void Update()
    {
        // Check for space bar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Record the time when the space bar is pressed
            spaceBarHoldStartTime = Time.time;
            isSpaceBarHeld = false;
        }

        // Check for space bar release
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Calculate the duration the space bar was held
            float holdDuration = Time.time - spaceBarHoldStartTime;

            // If held for a short duration, call PlayGame
            if (!isSpaceBarHeld && holdDuration < 0.5f)
            {
                PlayGame();
            }

            isSpaceBarHeld = false;
        }

        // Check for space bar hold
        if (Input.GetKey(KeyCode.Space))
        {
            // If space bar is held for the specified duration, call QuitGame
            if (Time.time - spaceBarHoldStartTime > holdDuration)
            {
                QuitGame();
                isSpaceBarHeld = true;
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneAudrey);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
