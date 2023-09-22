using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public Transform attackPoint;
    //public float BkAttack;
    public LayerMask quaivatlayer;
    AudioManager audioManager;
    public int damage;

    /*public float lastHit;
    public float cooldown;*/
    
    private void OnEnable()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
       /* float T = Time.time - lastHit;
        if(T < cooldown) return;
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
            lastHit = Time.time;
        }*/
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }

    private void Attack()
    {
        //animation tấn công
        anim.SetTrigger("Atk_Q");
        audioManager.PlayAudioClip(audioManager.Chems);
        Collider2D[] hitKethu = Physics2D.OverlapCircleAll(attackPoint.position, 1f, quaivatlayer);
        foreach (Collider2D monster in hitKethu)
        {
            monster.GetComponent<monster>().DamageQ(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(attackPoint.position, 1f);
    }
}
