using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
   public void LoadProfile()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Profile");
    }

    private void OnApplicationQuit()
    {
        SaveScene();
    }
    public void SaveScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastSceneIndex", currentSceneIndex);
    }

    public void LoadLastScene()
    {
        if (PlayerPrefs.HasKey("LastSceneIndex"))
        {
            int lastSceneIndex = PlayerPrefs.GetInt("LastSceneIndex");
            SceneManager.LoadScene(lastSceneIndex);
        }
        else
        {
            // Nếu không tồn tại giá trị lưu trước đó, load scene mặc định
            SceneManager.LoadScene("Man1");
        }
    }
}
