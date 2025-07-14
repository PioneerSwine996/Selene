using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class TileBasedSceneChanger : MonoBehaviour
{
    public Tilemap tilemap; // Assign your Tilemap in Inspector
    public TileBase[] validTiles; // Drag the 4 target tiles here
    public string targetSceneName = "NextScene"; // Scene to load

    private void Update()
    {
        Vector3 worldPos = transform.position;
        Vector3Int tilePos = tilemap.WorldToCell(worldPos);
        TileBase currentTile = tilemap.GetTile(tilePos);

        if (currentTile != null && IsOnValidTile(currentTile))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(targetSceneName);
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