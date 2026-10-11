using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;

    public TMP_Text collectiblesNumbersText;
    private int collectiblesNumber;

    public TMP_Text totalCollectiblesNumbersText;
    private int totalCollectiblesNumber;

    [Header("Cambio de nivel")]
    [SerializeField] private string siguienteEscena;

    private bool cambiandoEscena = false;

    void Start()
    {
        totalCollectiblesNumber = transform.childCount;
        totalCollectiblesNumbersText.text = totalCollectiblesNumber.ToString();

        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 0.7f);
    }

    void Update()
    {
        if (transform.childCount <= 0 && !cambiandoEscena)
        {
            cambiandoEscena = true;

            Time.timeScale = 1f;
            AudioListener.pause = false;

            SceneManager.LoadScene(siguienteEscena);
        }
    }

    public void AddCollectible()
    {
        audioSource.Play();

        collectiblesNumber = collectiblesNumber + 1;
        collectiblesNumbersText.text = collectiblesNumber.ToString();
    }
}