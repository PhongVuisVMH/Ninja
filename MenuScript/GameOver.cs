using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    AudioManager audioManager;
    public string nameScene;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }
    public void PlayAgain()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene(nameScene);
    }
    public void Exit()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        GameManager.Instance.ExitToSave();
        SceneManager.LoadScene("Menu");
    }
}
