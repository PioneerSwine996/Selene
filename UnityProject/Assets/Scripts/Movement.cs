using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sensitivity;
    [SerializeField] private Animator anim;
    private float xRotation;

    public bool canMove = true;



    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        Animation();
    }

    void FixedUpdate()
    {
        if (!canMove) return;
        Move();
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Animation()
    {
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            anim.SetBool("WalkS", true); 
        }
        else
        {
            anim.SetBool("WalkS", false);
        }
    }
}