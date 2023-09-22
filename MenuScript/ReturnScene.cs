
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnScene : MonoBehaviour
{
    public GameObject LoaderUI;
    public Slider LoadingSlider;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }
    public void GoBack(int index)
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(index));
        Time.timeScale = 1.0f;
    }

    public IEnumerator LoadScene_Coroutine(int index)
    {
        LoadingSlider.value = 0;
        LoaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(2);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            LoadingSlider.value = progress;
            if (progress >= 0.9f)
            {
                LoadingSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
