using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit button clicked. Application will exit.");
        Application.Quit();
    }
}
