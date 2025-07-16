using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject player;

    public void GoToScene(string sceneName)
    {
        // Save position
        if (SceneDataManager.Instance != null)
            SceneDataManager.Instance.lastPlayerPosition = player.transform.position;

        SceneManager.LoadScene(sceneName);
    }
}