using UnityEngine;
using UnityEngine.UI;

public class Open_Close : MonoBehaviour
{
    public GameObject panel;
    public Button NotActive1;
    public Button NotActive2;
    [SerializeField]private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }
    public void Open()
    {
        audioManager.PlayAudioClip(audioManager.Clicks);
        panel.SetActive(true);
        NotActive1.interactable = false;
        NotActive2.interactable = false;
    }

    public void Close()
    {
        audioManager.PlayAudioClip(audioManager.Clicks);
        panel.SetActive(false);
        NotActive1.interactable = true;
        NotActive2.interactable = true;
    }
}
