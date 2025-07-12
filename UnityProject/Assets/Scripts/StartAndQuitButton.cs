using UnityEngine;

public class StartAndQuitButton : MonoBehaviour
{
    public AudioFader audioFader;
    public string gameSceneName;

    public void QuitGame()
    {
        Debug.Log("Quit button clicked. Application will exit.");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Start button clicked. Fading out music and starting loading screen...");
        audioFader.FadeOutAndLoadScene();
    }
}