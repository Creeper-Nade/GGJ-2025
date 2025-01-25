using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance { get; private set; } // 单例引用
    public Image fadeImage; // 引用 Image
    public float fadeDuration = 1f; // 淡入淡出的持续时间

    private void Awake()
    {
        // 确保单例的唯一性
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 如果已经存在一个实例，销毁多余的
            return;
        }

        DontDestroyOnLoad(gameObject); // 切换场景时保留
    }

    private void Start()
    {
       
    }

    public void LoadSceneWithFade(string sceneName)
    {
        // 开始切换场景
        StartCoroutine(FadeOutAndSwitchScene(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float timer = fadeDuration;
        Color color = fadeImage.color;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            color.a = 1 - (timer / fadeDuration); // 逐渐变透明
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 0);
    }

    private IEnumerator FadeOutAndSwitchScene(string sceneName)
    {
        float timer = 0f;
        Color color = fadeImage.color;

        // 淡出效果
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration; // 逐渐变不透明
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 1);

        // 切换场景
        SceneManager.LoadScene(sceneName);

        // 等待一帧，确保新场景加载完成
        yield return null;

        // 淡入效果
        timer = fadeDuration;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            color.a = timer / fadeDuration; // 逐渐变透明
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 0); // 完全透明
    }
}