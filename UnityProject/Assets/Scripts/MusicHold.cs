using UnityEngine;

public class SceneDataManager : MonoBehaviour
{
    public static SceneDataManager Instance;

    public Vector3 lastPlayerPosition;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}