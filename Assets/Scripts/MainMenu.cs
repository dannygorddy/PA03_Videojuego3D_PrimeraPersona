using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelMenuPrincipal;
    [SerializeField] private GameObject panelOpciones;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 1f;

        panelMenuPrincipal.SetActive(true);
        panelOpciones.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions()
    {
        panelMenuPrincipal.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void BackToMainMenu()
    {
        panelOpciones.SetActive(false);
        panelMenuPrincipal.SetActive(true);
    }
    public void SetSFXVolume(float volume)
{
    PlayerPrefs.SetFloat("SFXVolume", volume);
    PlayerPrefs.Save();
}

public void SetSensitivity(float sensitivity)
{
    PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
    PlayerPrefs.Save();
}

    public void Quit()
    {
        Application.Quit();
    }
}