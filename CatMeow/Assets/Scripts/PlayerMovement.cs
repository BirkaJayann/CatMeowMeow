using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;

    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (anim == null) anim = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessInputs();
        Animate();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(moveX, moveY);

        if (input != Vector2.zero)
        {
            lastMoveDirection = input.normalized;
        }

        moveDirection = input.normalized;
    }

    void Move()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    void Animate()
    {
        anim.SetFloat("MoveX", moveDirection.x);
        anim.SetFloat("MoveY", moveDirection.y);
        anim.SetFloat("MoveMagnitude", moveDirection.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }
}
