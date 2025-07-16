using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    void Start()
    {
        if (SceneDataManager.Instance != null && SceneDataManager.Instance.lastPlayerPosition != Vector3.zero)
        {
            transform.position = SceneDataManager.Instance.lastPlayerPosition;
        }
    }
}