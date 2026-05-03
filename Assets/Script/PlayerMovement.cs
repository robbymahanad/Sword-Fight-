using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private ContactFilter2D contactFilter;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private EventAnim animatorEvent;
    private bool onGround;
    private bool isMoving;
    private bool canMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        OnGround();
        if (!OnGround())
        {
            animator.SetTrigger("Jump");
        }
        rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }

    public void PlayerMove(Vector2 moveDir)
    {
        if (moveDir.x == 0)
        {
            animator.SetInteger("AnimState", 0);
        }
        else if (moveDir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("AnimState", 2);
        }
        else if (moveDir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("AnimState", 2);
        }
        rb.linearVelocity = new Vector2(moveDir.x * moveSpeed, rb.linearVelocityY);
        //if (!animatorEvent.isBusy)
        //{
        //    rb.linearVelocity = new Vector2(moveDir.x * moveSpeed, rb.linearVelocityY);
        //}

    }
    public void PlayerJump()
    {
        if (OnGround())
        {
            rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
        }
    }
    public bool OnGround()
    {
        animator.SetBool("Grounded", rb.IsTouching(contactFilter));
        return rb.IsTouching(contactFilter);
    }
}
