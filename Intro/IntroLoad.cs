using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLoad : MonoBehaviour
{
    public int wait_time = 10;
    public string sceneName;
    public string scenePath;
    int indexScene;
    private void Start()
    {
        indexScene = PlayerPrefs.GetInt("SavedScene", 0);
        //Debug.Log(indexScene);
        StartCoroutine (LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(wait_time);
        if(indexScene == 0)
        {
            SceneManager.LoadScene(sceneName);
        }
        else SceneManager.LoadScene(scenePath);
    }
}
