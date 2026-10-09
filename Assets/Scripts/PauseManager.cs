using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject panelOpcionesPausa;
    [SerializeField] private FirstPersonController playerController;

    private bool isPaused = false;

    private void Start()
    {
        panelPausa.SetActive(false);
        panelOpcionesPausa.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;

        panelPausa.SetActive(true);
        panelOpcionesPausa.SetActive(false);

        Time.timeScale = 0f;
        AudioListener.pause = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerController != null)
        {
            playerController.enabled = false;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;

        panelPausa.SetActive(false);
        panelOpcionesPausa.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }

    public void OpenOptions()
    {
        panelPausa.SetActive(false);
        panelOpcionesPausa.SetActive(true);
    }

    public void BackToPause()
    {
        panelOpcionesPausa.SetActive(false);
        panelPausa.SetActive(true);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();

        MusicManager musicManager = FindFirstObjectByType<MusicManager>();

        if (musicManager != null)
        {
            musicManager.SetMusicVolume(volume);
        }
    }

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();

        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null)
        {
            AudioSource audioSource = gameManager.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.volume = volume;
            }
        }
    }

    public void SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        PlayerPrefs.Save();

        if (playerController != null)
        {
            playerController.mouseSensitivity = sensitivity;
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene("MainMenu");
    }
}