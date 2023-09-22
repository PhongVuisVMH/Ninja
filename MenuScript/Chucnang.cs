using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Chucnang : MonoBehaviour
{
    //gọi biến
    public static Chucnang instance;
    public GameObject canvasMenuPause;
    public GameObject EventSystem;
    [SerializeField] private AudioManager audioManager;
    public GameObject createUserInfor;

    //Loading
    public GameObject LoaderUI;
    public Slider LoadingSlider;
    

    public TMP_InputField username;
    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        if (instance == null) instance = this;
        
        else
        {
            if (instance == this) Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        if (Connection.instance == null) return;
        else
        {
            Connection.instance.connection();
        }
    }

    //Chơi mới
    public void ChoiMoi()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(3));
        Time.timeScale = 1.0f;
        //CheckUser();
    }

    //Chơi tiếp
    public void Profile(int index)
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        //GameManager.Instance.load.LoadLastScene();
        StartCoroutine(LoadScene_Coroutine(index));
        Time.timeScale = 1f;
    }
    public void PlayAgain(int index)
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        //GameManager.Instance.load.LoadLastScene();
        StartCoroutine(LoadScene_Coroutine(index));
        Time.timeScale = 1f;
    }

    //Chơi tiếp của menu pause
    public void ChoiTiep()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        gameObject.SetActive(false);
        Time.timeScale = 1;
        canvasMenuPause.SetActive(false);
        EventSystem.SetActive(true);
    }

    //thoát
    public void Thoat()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        GameManager.Instance.load.SaveScene();
        Destroy(gameObject, 4f);

    }

    public void CheckUser() //Nếu click vào chơi mới, thì sẽ bật panel để ghi tên người dùng
    {
        //CheckUserName.instance.CheckUserInfor();
        createUserInfor.SetActive(true);
    }

    public void CreateUser() //Nếu click vào Save trong chơi mới, thì sẽ làm như dưới
    {
        audioManager.PlayAudioClip(audioManager.Clicks);
        SaveScene_Level.instance.addName();
        createUserInfor.SetActive(false);
        ChoiMoi();
    }

    /*private IEnumerator DelayExit()
    {
        yield return new WaitForSeconds(1);
        createUserInfor.SetActive(false);
    }*/

    public void Pause()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        canvasMenuPause.SetActive(true);
       // gameObject.SetActive(true);
        Time.timeScale = 0;
    }
   
    public void CloseSetUser()
    {
        audioManager.PlayAudioClip(audioManager.Clicks);
        createUserInfor.SetActive(false);
    }

    public void Exit(int index)
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        StartCoroutine(LoadScene_Coroutine(index));
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        Application.Quit();
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
