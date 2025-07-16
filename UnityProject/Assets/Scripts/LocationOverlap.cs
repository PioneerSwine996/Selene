using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LocationBasedSceneChanger : MonoBehaviour
{
    public Vector2[] targetPositions; // Array of positions to check
    public float radius = 1.0f; // Radius within which the player must be
    public string targetSceneName; // Scene to load
    public GameObject targetObject; // GameObject to show/hide

    private HashSet<Vector2> visitedPositions = new HashSet<Vector2>();

    private void Update()
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        Debug.Log("Player position: " + playerPos);

        bool isOverlappingAnyTarget = false;

        foreach (Vector2 targetPos in targetPositions)
        {
            if (Vector2.Distance(playerPos, targetPos) <= radius)
            {
                visitedPositions.Add(targetPos);
                isOverlappingAnyTarget = true; // Player is overlapping at least one target position
            }
        }

        // Show the targetObject only when overlapping a location
        if (targetObject != null)
        {
            targetObject.SetActive(isOverlappingAnyTarget);
        }

        // Allow scene change if all target positions have been visited and the player presses E
        if (Input.GetKeyDown(KeyCode.E) && HasVisitedAllPositions())
        {
            Debug.Log("Loading scene: " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
    }

    private bool HasVisitedAllPositions()
    {
        foreach (Vector2 targetPos in targetPositions)
        {
            if (!visitedPositions.Contains(targetPos))
                return false;
        }
        return true;
    }
}