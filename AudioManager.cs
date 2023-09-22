using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("....................AudioSource...................")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------------------AudioClip---------------------")]
    public AudioClip BackGround;
    public AudioClip CheckPoint;
    public AudioClip Clicks;
    public AudioClip Chems;
    public AudioClip Coins;
    public AudioClip EnemyDamage;
    public AudioClip Jump;
    public AudioClip GameOver;
    public AudioClip LevelComplete;
    public AudioClip Death;
    public AudioClip Shoot;
    public AudioClip Zombie_Cream;
    public AudioClip Zombie_breath;
    public static AudioManager instance;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
            MusicSource.clip = BackGround;
            MusicSource.Play();
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        
    }

    public void PlayAudioClip(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
