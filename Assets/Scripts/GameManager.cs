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


    void Start()
    {
        totalCollectiblesNumber = transform.childCount; 
        totalCollectiblesNumbersText.text = totalCollectiblesNumber.ToString();
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        
    }

    public void AddCollectible()
    {
        audioSource.Play();
        collectiblesNumber = collectiblesNumber + 1;
        collectiblesNumbersText.text = collectiblesNumber.ToString();
    }
}
