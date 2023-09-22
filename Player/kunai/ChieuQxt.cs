using UnityEngine;

public class ChieuQxt : MonoBehaviour
{
    public GameObject weapons;
    public float lastshot;
    public float Cooldown;
    private Animator anim;
    AudioManager manager;
    bool isShooting = false;
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float T = Time.time - lastshot;
        if (T < Cooldown & isShooting == false) return;
        else
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetTrigger("Atk_Q");
                Instantiate(weapons, transform.position, transform.rotation);
                lastshot = Time.time;
                manager.PlayAudioClip(manager.Shoot);
            }
        }
    }
}
