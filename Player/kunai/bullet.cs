using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D weapons;
    public float speed;
    public int damage;
    public static bullet instance;
    void Start()
    {
        if(instance == null) instance = this;
        weapons = GetComponent<Rigidbody2D>();
        Shot();
    }
    void Shot()
    {
        if(PlayerController.instance.transform.localScale.x >0 )
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward); //quay hướng mũi tên
            weapons.velocity = new Vector2(speed, weapons.velocity.y); //hướng bay của đạn
        }
        else if(PlayerController.instance.transform.localScale.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            weapons.velocity = new Vector2(-speed, weapons.velocity.y);
        }
        Destroy(gameObject, 1f);
    }

}
