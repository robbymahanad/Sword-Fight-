using UnityEngine;

public class UnitCollision : MonoBehaviour
{
    [SerializeField] private LayerMask attackLayer;
    [SerializeField] private Player playerEnemy;
    [SerializeField] private Player playerSelf;

    private void Awake()
    {
        playerSelf = GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerEnemy = GetComponentInParent<Player>();
        playerSelf.TakeDamage(playerEnemy.SetDamage());
        Debug.Log(collision.gameObject);
    }
}
