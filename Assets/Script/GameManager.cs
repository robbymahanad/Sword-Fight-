using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Player enemy;

    private void Update()
    {
        PlayerStatus();
    }
    public void PlayerStatus()
    {
        if (!player.isAlive)
        {
            EventManager.Instance.PlayerDeath();
        }
        if (!enemy.isAlive)
        {
            EventManager.Instance.EnemyDeath();
        }
    }
}
