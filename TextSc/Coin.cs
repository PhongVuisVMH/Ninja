using UnityEngine;

public class Coin : MonoBehaviour
{
    //private int CoinPoint = 1;
    //private GameManager gm;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }
  
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ninja")
        {
            audioManager.PlayAudioClip(audioManager.Coins);
            GameManager.Instance.Scores += 10;
            Destroy(gameObject);
        }
    }
}
