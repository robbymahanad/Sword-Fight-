using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Player player;

    private void Update()
    {
        HealthBarUpdate(player.currentHitPoint,player.maxHitPoint);
    }
    private void HealthBarUpdate(float currentHealth , float maxHealth)
    {
        float healthChange = currentHealth / maxHealth;
        healthBarImage.fillAmount = healthChange;
    }
}
