using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class CheckUserName : MonoBehaviour
{
    public GameObject btnChoiTiep;
    public static CheckUserName instance;
    [SerializeField] private AudioManager audioManager;
    public GameObject LoaderUI;
    public Slider LoadingSlider;
    int indexScene;

    private void Awake()
    {
        indexScene = PlayerPrefs.GetInt("SavedScene", 0);
        if (instance == null) instance = this;
        else
        {
            if (instance == this) Destroy(gameObject);
        }
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    /*private void Update()
    {
        if (btnChoiTiep.activeSelf == true)
        {
            return;
        }
        else
        {
            SaveScene_Level.instance.CheckInfor();
        }
    }*/

    public void ChoiTiep()
    {
        audioManager.PlayAudioClip(audioManager.Clicks);
        StartCoroutine(LoadScene_Coroutine(indexScene));
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
