using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float maxHitPoint;
    [SerializeField] private float damage;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private Animator animator;
    [SerializeField] public PlayerMovement playerMovement;
    public LayerMask layerToIgnore;
    public float currentHitPoint;
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    private Player player;
    private Enemy enemy;
    public bool isAlive;

    private void Awake()
    {
        playerCollider = GetComponent<Collider2D>();
        
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        currentHitPoint = maxHitPoint;
        player=GetComponent<Player>();
        enemy = GetComponent<Enemy>();
    }

    public void TakeDamage(float damage)
    {
        if (currentHitPoint <= 0)
        {
            animator.SetTrigger("Death");
            PlayerDied();
        }
        currentHitPoint = currentHitPoint - damage;

    }
    public void Attack()
    {
        attackPoint.SetActive(true);
    }
    public void AttackAnim()
    {
        if (playerMovement.OnGround())
        {
            animator.SetTrigger("Attack");
        }
    }
    public void EndAttack()
    {
        attackPoint.SetActive(false);
    }
    public float SetDamage()
    {
        return damage;
    }
    public void PlayerDied()
    {
        playerCollider.excludeLayers = layerToIgnore;
        playerMovement.enabled = false;
    }
        
}
