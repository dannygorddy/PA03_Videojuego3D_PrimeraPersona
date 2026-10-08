using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            audioSource = GetComponent<AudioSource>();

            // Recupera el volumen guardado.
            float volumenGuardado = PlayerPrefs.GetFloat("MusicVolume", 0.7f);

            if (audioSource != null)
            {
                audioSource.volume = volumenGuardado;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;

            // Guarda el volumen elegido.
            PlayerPrefs.SetFloat("MusicVolume", volume);
            PlayerPrefs.Save();
        }
    }
}
