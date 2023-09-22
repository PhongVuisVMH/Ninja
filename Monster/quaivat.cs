using UnityEngine;

public class quaivat : MonoBehaviour
{
    public float maxhealth;
    private float hpHienTai;
    public Animator ani;
   // private KillCount kill;

    void Start()
    {
        hpHienTai = maxhealth;
    }

    // Update is called once per frame
    public void GayDamage(int damage)
    {
        hpHienTai -= damage;

        //animation hurt
        ani.SetTrigger("1_hurt");

        if(hpHienTai < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Nhan vat da chet!");

        //Animator die
        ani.SetBool("1_die", true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
