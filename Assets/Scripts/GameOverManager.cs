using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private FirstPersonController playerController;

    private bool gameOver = false;

    private void Start()
    {
        panelGameOver.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (gameOver)
            return;

        gameOver = true;

        panelGameOver.SetActive(true);

        Time.timeScale = 0f;
        AudioListener.pause = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerController != null)
        {
            playerController.enabled = false;
        }
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene("MainMenu");
    }
}