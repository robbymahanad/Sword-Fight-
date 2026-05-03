using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Player playerScript;
    private Vector2 distance;
    private Vector2 moveDir;
    [SerializeField] private float minimumDistance = 1f;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private EventAnim eventAnim;
    private Rigidbody2D rb;
    private RigidbodyConstraints2D originalConstraints;

    private void Awake()
    {
        //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb =GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        playerScript = GetComponent<Player>();
        originalConstraints=rb.constraints;
    }
    private void FixedUpdate()
    {
        CalculateDistance();
        ChasePlayer();
    }
    private Vector2 CalculateDistance()
    {
        distance = player.position - transform.position;
        if (distance.x > minimumDistance)
        {
            moveDir = Vector2.right;
            rb.constraints = originalConstraints;
        }
        else if (distance.x < -minimumDistance)
        {
            moveDir = Vector2.left;
            rb.constraints = originalConstraints;
        }
        else if (distance.x <= minimumDistance && distance.x >= -minimumDistance)
        {
            moveDir = Vector2.zero;
            if (!eventAnim.isBusy)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                playerScript.AttackAnim();

            }
        }

        return distance;
    }
    private void ChasePlayer()
    {
        if (!eventAnim.isBusy)
        {
            playerMovement.PlayerMove(moveDir);
      

        }
    }
}
