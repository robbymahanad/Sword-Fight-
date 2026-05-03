using UnityEngine;

public class UnitCollision : MonoBehaviour
{
    [SerializeField] private LayerMask attackLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Player playerEnemy;
    [SerializeField] private Player playerSelf;
    [SerializeField] private Vector3 playerJumpPos;
    [SerializeField] private ContactFilter2D contactFilter;
    private float moveAsideDir =0;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerSelf = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PreventUnitStacking();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & attackLayer) == 0)
            return;
        playerEnemy = collision.gameObject.GetComponentInParent<Player>();
        playerSelf.TakeDamage(playerEnemy.SetDamage());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) == 0)
            return;
        playerJumpPos=collision.transform.position;
        if (transform.position.x >= playerJumpPos.x)
        {
            moveAsideDir = 1f;
        }
        else if (transform.position.x < playerJumpPos.x)
        {
            moveAsideDir = -1f;
        }
    }
    private void PreventUnitStacking()
    {
        if(rb.IsTouching(contactFilter))
        {
            transform.position += new Vector3(5f*moveAsideDir, 0f, 0f) * Time.deltaTime;
        }
    }
}
