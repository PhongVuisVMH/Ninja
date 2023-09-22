using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject panel;
    public GameObject setting;
    //Loading
    public GameObject LoaderUI;
    public Slider LoadingSlider;

    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        panel.SetActive(false);
    }

    public void Turn()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        //StartCoroutine(LoadScene_Coroutine());
        panel.SetActive(true);
    }

    public void SettingOpen()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        setting.SetActive(true);
    }

    public void SettingClose()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        setting.SetActive(false);
    }

    public void LoadLevel1()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(1));
        Time.timeScale = 1f;
    }
    public void LoadLevel2()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(2));
        Time.timeScale = 1f;
    }
    public void LoadLevel3()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(3));
        Time.timeScale = 1f;
    }
    public void LoadLevel4()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(4));
        Time.timeScale = 1f;
    }
    public void LoadLevel5()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(5));
        Time.timeScale = 1f;
    }
    public void LoadLevel6()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(0));
        Time.timeScale = 1f;
    }

    public IEnumerator LoadScene_Coroutine(int index)
    {
        LoadingSlider.value = 0;
        LoaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
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
