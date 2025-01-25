using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    public AudioClip[] audioClips; 
    public AudioClip[] bgmClips;   
    private AudioSource sfxAudioSource; 
    private AudioSource bgmAudioSource; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        sfxAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource = gameObject.AddComponent<AudioSource>();

        bgmAudioSource.loop = true;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChecKbgm();
    }

    public void ChecKbgm()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Menu")
        {
            PlayBGM(0); 
        }
        else if (sceneName == "Rest")
        {
            PlayBGM(1); 
        }
    }

    public void PlaySFX(int index)
    {
        if (index < 0 || index >= audioClips.Length)
        {
            Debug.LogWarning("ÒôÐ§Ë÷Òý³¬³ö·¶Î§£¡");
            return;
        }

        if (audioClips[index] != null)
        {
            sfxAudioSource.PlayOneShot(audioClips[index]);
        }
        else
        {
            Debug.LogWarning($"ÒôÐ§ {index} Î´ÉèÖÃ£¡");
        }
    }

    public void PlayBGM(int index)
    {
        if (index < 0 || index >= bgmClips.Length)
        {
            Debug.LogWarning("BGM Ë÷Òý³¬³ö·¶Î§£¡");
            return;
        }

        if (bgmClips[index] != null)
        {
            if (bgmAudioSource.clip != bgmClips[index])
            {
                bgmAudioSource.clip = bgmClips[index];
                bgmAudioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning($"BGM {index} Î´ÉèÖÃ£¡");
        }
    }

    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
}