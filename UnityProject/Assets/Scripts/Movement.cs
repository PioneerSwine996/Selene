using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sensitivity;
    [SerializeField] private Animator anim;
    private float xRotation;



    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animation();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
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