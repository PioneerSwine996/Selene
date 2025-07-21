using UnityEngine;
using System.Collections;
using System;

public class NPCHover : MonoBehaviour
{
    public Vector2 targetPosition;
    public float radius = 1.0f;
    public GameObject targetObject;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject targetObject4;
    public GameObject player;

    private int interactionState = 0;
    private bool isHovering;

    private void Update()
    {
        Debug.Log("isHovering: " + isHovering);
        if (isHovering)
        {
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            float distance = Vector2.Distance(playerPos, targetPosition);

            Debug.Log("Already hovering, waiting for interaction to complete. isHovering: " + isHovering);
            if (Input.GetKeyDown(KeyCode.E) && distance <= radius)
            {
                isHovering = true;
                HandleInteraction();
            }
            return;
        }
        else
        {
            Debug.Log("Not hovering, checking for interaction. isHovering: " + isHovering);
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            float distance = Vector2.Distance(playerPos, targetPosition);

            if (targetObject != null)
            {
                targetObject.SetActive(distance <= radius);
                Debug.Log("targetObject active: " + targetObject.activeSelf);
            }

            if (Input.GetKeyDown(KeyCode.E) && distance <= radius)
            {
                Debug.Log("E key pressed and within radius");
                isHovering = true;
                Debug.Log("isHovering just set to TRUE on: " + gameObject.name);
                HandleInteraction();
            }
        }
    }
private void HandleInteraction()
{
    var movement = player.GetComponent<PlayerMovement>();
    if (movement != null)
        movement.canMove = false;

    switch (interactionState)
    {
        case 0:
            if (targetObject != null) targetObject.SetActive(false);
            if (targetObject2 != null) targetObject2.SetActive(true);
            if (targetObject3 != null) targetObject3.SetActive(true);
            interactionState++;
            break;

        case 1:
            if (targetObject3 != null) targetObject3.SetActive(false);
            if (targetObject4 != null) targetObject4.SetActive(true);
            interactionState++;
            break;

        case 2:
            if (targetObject4 != null) targetObject4.SetActive(false);
            if (targetObject2 != null) targetObject2.SetActive(false);
            if (targetObject != null) targetObject.SetActive(false);

            interactionState = 0;
            isHovering = false;

            if (movement != null)
                movement.canMove = true;

            break;
    }
}
}