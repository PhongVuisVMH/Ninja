using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission : MonoBehaviour
{
    public string nameScene;
    AudioManager manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ninja")
        {
            manager.PlayAudioClip(manager.LevelComplete);
            SceneManager.LoadScene(nameScene);
            Destroy(gameObject, 2f);
        }
    }
}
