using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sensitivity;
    private float xRotation;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 forceDir = Vector2.zero;

        // replace the falses with input checks for W, A, S, D
        // try to figure out for yourself which is which, note that x is left and right, and z is back and forth
        if (Input.GetKey(KeyCode.W))
        {
            forceDir += new Vector2((transform.forward).x, (transform.forward).z);
            Debug.Log("Moving Forward");
        }
        if (Input.GetKey(KeyCode.S))
        {
            forceDir = new Vector2((-transform.forward).x, (-transform.forward).y);
            Debug.Log("Moving Bacward");
        }
        if (Input.GetKey(KeyCode.D))
        {
            forceDir = new Vector2((transform.right).x, (transform.right).z);
            Debug.Log("Moving Right");
        }
        if (Input.GetKey(KeyCode.A))
        {
            forceDir = new Vector2((-transform.right).x, (-transform.right).z);
            Debug.Log("Moving Left");
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            forceDir = Vector2.zero;
            Debug.Log("Not Moving Forward or Backward");
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            forceDir = Vector2.zero;
            Debug.Log("Not Moving Left or Right");
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            forceDir = new Vector2((transform.forward - transform.right).x, (transform.forward - transform.right).z);
            Debug.Log("Moving Forward and Left");
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            forceDir = new Vector2((transform.forward + transform.right).x, (transform.forward + transform.right).z);
            Debug.Log("Moving Forward and Right");
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            forceDir = new Vector2((-transform.forward - transform.right).x, (-transform.forward - transform.right).z);
            Debug.Log("Moving Backward and Left");
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            forceDir = new Vector2((-transform.forward + transform.right).x, (-transform.forward + transform.right).z);
            Debug.Log("Moving Backward and Right");
        }
        if (forceDir.magnitude < .01f)
        {
            rb.AddForce(-rb.linearVelocity);
        }
        else
        {
            rb.AddForce(forceDir.normalized * Mathf.Max(0, (moveSpeed - rb.linearVelocity.magnitude)));
        }
    }
}