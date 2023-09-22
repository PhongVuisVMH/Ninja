using UnityEngine;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    public int PointEnemy;
    public float speed ;
    Rigidbody2D enemy;
    //máu quái
    private float hpHienTai;
    public float hpMax;
    //public float damageOfkunai;
    //public bullet w;
    public float damageOfMonster;

    public static monster instace;
    public Slider HealBar;

    BoxCollider2D box;
    AudioManager audioManager;

    //Animator ani;
    private void Awake()
    {
        enemy = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        //ani = GetComponent<Animator>();
        if(instace == null)
        {
            instace = this;
        }
        
    }
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        hpHienTai = hpMax;
        HealBar.maxValue = hpMax;
        HealBar.value = hpHienTai;
    }

    void FixedUpdate()
    {
        enemy.velocity = new Vector2(speed, enemy.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "limit")
        {
            //giới hạn di chuyển
            transform.Rotate(0, 180, 0);
            speed *= -1;
        }
        else if (col.gameObject.tag == "bullet")
        {
            audioManager.PlayAudioClip(audioManager.EnemyDamage);
            //create - hp of monster
            hpHienTai -= bullet.instance.damage;
            HealBar.value = hpHienTai;
            if (hpHienTai <= 0)
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.Scores += PointEnemy;
                    GameManager.Instance.kill += 1;
                }
                Destroy(gameObject);
            }
        }
        if (col.gameObject.tag == "viendan")
        {
            audioManager.PlayAudioClip(audioManager.EnemyDamage);
            hpHienTai -= 30;
            HealBar.value = hpHienTai;
            if (hpHienTai <= 0)
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.Scores += PointEnemy;
                    GameManager.Instance.kill += 1;
                }
                Destroy(gameObject);
            }
        }
    }

    public void DamageQ(int damage)
    {
        hpHienTai -= damage;
        audioManager.PlayAudioClip(audioManager.EnemyDamage);
        HealBar.value = hpHienTai;
        if (hpHienTai <= 0)
        {            
            if (GameManager.Instance == null) return;
            else
            {
                audioManager.PlayAudioClip(audioManager.Death);
                GameManager.Instance.Scores += PointEnemy;
                GameManager.Instance.kill += 1;
            }
            Destroy(gameObject);

        }
    }

    public void DamageMonster()
    {
        playerHealth.instance.hpHienTai -= damageOfMonster;
    }

    //Nếu va chạm với player thì chỉ có con đường chết
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (hpHienTai <= 0)
            {
                if (GameManager.Instance == null) return;
                else 
                {
                    GameManager.Instance.Scores += PointEnemy;
                    GameManager.Instance.kill += 1;
                };
            }
            else return;
            box.enabled = false;
            enemy.gravityScale = 1;
            Destroy(gameObject);
        }
    }
}
