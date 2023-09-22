using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float hpMaxPlayer;
    public float hpHienTai;
    private Image thanhmau;
    public static playerHealth instance;
    private bool isDeath = false;
    private void Awake()
    {
        if (instance == null) instance = this;
         else if(instance == this) Destroy(gameObject);
        
        hpHienTai = hpMaxPlayer;
        GameObject thanhHP = GameObject.Find("thanhmau");
        if (thanhHP == null) return;
        else
        {
            thanhmau = thanhHP.GetComponent<Image>();
            thanhmau.fillAmount = hpMaxPlayer;
        }
        
    }

    private void FixedUpdate()
    {
        UpdateHP();
        //PlayerDie();
        if (hpHienTai <= 0 && !isDeath)
        {
            GameManager.Instance.Death();
            isDeath = true;
        }
    }
    
    void UpdateHP()
    {
        thanhmau.fillAmount = hpHienTai / hpMaxPlayer;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       //audioManager.PlayAudioClip(audioManager.Hurt);
        if (col.gameObject.tag == "enemy")
        {
            monster.instace.DamageMonster();
        }
    }

}
