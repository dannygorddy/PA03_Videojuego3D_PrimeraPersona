using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    [SerializeField] private GameObject ventanaObjetivo;
    [SerializeField] private FirstPersonController playerController;
    [SerializeField] private PauseManager pauseManager;

    private void Start()
    {
        // Desactiva la pausa mientras está abierta la ventana de objetivo
        if (pauseManager != null)
        {
            pauseManager.enabled = false;
        }

        // Mostrar ventana de objetivo
        ventanaObjetivo.SetActive(true);

        // Pausar el juego
        Time.timeScale = 0f;
        AudioListener.pause = true;

        // Desactivar movimiento y cámara del jugador
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        // Mostrar el cursor después de un frame
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
        // Ocultar ventana
        ventanaObjetivo.SetActive(false);

        // Iniciar el juego
        Time.timeScale = 1f;
        AudioListener.pause = false;

        // Ocultar y bloquear cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Activar nuevamente al jugador
        if (playerController != null)
        {
            playerController.enabled = true;
        }

        // Activar la pausa recién después de comenzar
        if (pauseManager != null)
        {
            pauseManager.enabled = true;
        }
    }
}