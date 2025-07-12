using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioFader : MonoBehaviour
{
    public AudioSource musicSource;
    public float fadeDuration = 2f;

    public CanvasGroup loadingScreenGroup;
    public string gameSceneName;

    public void FadeOutAndLoadScene()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float startVolume = musicSource.volume;
        float time = 0f;

        loadingScreenGroup.gameObject.SetActive(true);

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, t);
            loadingScreenGroup.alpha = Mathf.Lerp(0f, 1f, t);

            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;

        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene(gameSceneName);
    }
}