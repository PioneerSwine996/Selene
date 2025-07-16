using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class TileBasedSceneChanger : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] validTiles;
    public GameObject targetObject;
    public string targetSceneName = "2nd Scene";

    private void Update()
    {
        Vector3 worldPos = transform.position;
        Vector3Int tilePos = tilemap.WorldToCell(worldPos);
        TileBase currentTile = tilemap.GetTile(tilePos);

        if (currentTile != null && IsOnValidTile(currentTile))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }

            Debug.Log("Player is on a valid tile.");

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneDataManager.Instance != null)
                {
                    SceneDataManager.Instance.lastPlayerPosition = transform.position;
                }

                Debug.Log("Loading scene: " + targetSceneName);
                SceneManager.LoadScene(targetSceneName);
            }
        }
        else
        {
            if (targetObject != null)
            {
                targetObject.SetActive(false);
            }
        }
    }

    private bool IsOnValidTile(TileBase tile)
    {
        foreach (TileBase validTile in validTiles)
        {
            if (tile == validTile)
                return true;
        }
        return false;
    }
}