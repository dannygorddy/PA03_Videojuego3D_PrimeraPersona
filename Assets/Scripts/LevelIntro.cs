using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    [SerializeField] private GameObject ventanaObjetivo;
    [SerializeField] private FirstPersonController playerController;

    private void Start()
{
    ventanaObjetivo.SetActive(true);

    Time.timeScale = 0f;
    AudioListener.pause = true;

    if (playerController != null)
    {
        playerController.enabled = false;
    }

    StartCoroutine(ActivarCursor());
}

private System.Collections.IEnumerator ActivarCursor()
{
    yield return null;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}

    public void ComenzarNivel()
    {
        ventanaObjetivo.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }
}