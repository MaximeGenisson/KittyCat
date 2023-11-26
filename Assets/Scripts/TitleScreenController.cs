using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public float holdDuration = 2f; // Adjust the hold duration as needed

    private bool actionCommand;
    private float clickTimmer;
    private bool isMonoClick;
    private bool isHoldClick;

    private void Update()
    {

        CheckButton();
       
        if (actionCommand)
        {
            clickTimmer += Time.deltaTime;
        }
        else
        {
                SetClickStatus();
                clickTimmer = 0;
        }
        if (isMonoClick){
            PlayGame();
        }

        // Check for space bar hold
        if(isHoldClick){
            QuitGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("CompleteScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }


    private void CheckButton(){
        if (Input.GetKeyDown(KeyCode.Space)){
            actionCommand = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space)){
            actionCommand = false;
        }
    }

    private void SetClickStatus(){
        if(clickTimmer >= holdDuration){
            isHoldClick=true;
        }
        else if(clickTimmer !=0){
            isMonoClick = true;
        }
    }
}
