using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public UnityEvent OnPlayerDeath;
    public UnityEvent Onpause;
    public UnityEvent Onresume;
    public UnityEvent OnRestart;
    public UnityEvent OnEnemyDeath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Optional: Make it persistent between scenes
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }
    public void PlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }
    public void EnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }
}
