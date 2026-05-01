using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHitPoint;
    [SerializeField] private float damage;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    private float currentHitPoint;


    public void TakeDamage(float damage)
    {
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
}
