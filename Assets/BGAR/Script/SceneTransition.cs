using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance { get; private set; } // ��������
    public Image fadeImage; // ���� Image
    public float fadeDuration = 1f; // ���뵭���ĳ���ʱ��

    private void Awake()
    {
        // ȷ��������Ψһ��
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // ����Ѿ�����һ��ʵ�������ٶ����
            return;
        }

        DontDestroyOnLoad(gameObject); // �л�����ʱ����
    }

    private void Start()
    {
       
    }

    public void LoadSceneWithFade(string sceneName)
    {
        // ��ʼ�л�����
        StartCoroutine(FadeOutAndSwitchScene(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float timer = fadeDuration;
        Color color = fadeImage.color;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            color.a = 1 - (timer / fadeDuration); // �𽥱�͸��
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 0);
    }

    private IEnumerator FadeOutAndSwitchScene(string sceneName)
    {
        float timer = 0f;
        Color color = fadeImage.color;

        // ����Ч��
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // �𽥱䲻͸��
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 1);

        // �л�����
        SceneManager.LoadScene(sceneName);

        // �ȴ�һ֡��ȷ���³����������
        yield return null;

        // ����Ч��
        timer = fadeDuration;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            color.a = timer / fadeDuration; // �𽥱�͸��
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 0); // ��ȫ͸��
    }
}