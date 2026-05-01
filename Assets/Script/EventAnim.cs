using UnityEditor.AnimatedValues;
using UnityEngine;

public class EventAnim : MonoBehaviour
{
    [SerializeField] private Player player;
    public bool isBusy = false;

    private void OnAttack()
    {
        player.Attack();
    }
    private void OnEndAttack()
    {
        player.EndAttack();
    }
    public void IsBusy(int busy)
    {
        if (busy == 0)
        {
            isBusy = false;
        }
        else if (busy == 1)
        {
            isBusy = true;
        }
    }
}
