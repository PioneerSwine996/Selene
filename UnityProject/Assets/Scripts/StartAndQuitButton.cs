using UnityEngine;

public class StartAndQuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit button clicked. Application will exit.");
        Application.Quit();
    }
    public void StartGame()
    {
        Debug.Log("Start button clicked. Game will start.");
        UnityEngine.SceneManagement.SceneManager.LoadScene("1st Scene");
        Debug.Log("If you see this, the scene has been loaded successfully.");
    }
}
