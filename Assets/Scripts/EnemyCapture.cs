using UnityEngine;

public class EnemyCapture : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameOverManager.ShowGameOver();
        }
    }
}