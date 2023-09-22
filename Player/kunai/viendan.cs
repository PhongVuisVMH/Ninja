using UnityEngine;

public class viendan : MonoBehaviour
{
    Rigidbody2D weapons;
    public float speed;

    void Start()
    {
        weapons = GetComponent<Rigidbody2D>();
        Shot();
        
    }
    void Shot()
    {
        if(PlayerController.instance.transform.localScale.x >0 )
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward); //quay hướng mũi tên
            weapons.velocity = new Vector2(speed, weapons.velocity.y); //hướng bay của đạn
        }
        else if(PlayerController.instance.transform.localScale.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            weapons.velocity = new Vector2(-speed, weapons.velocity.y);
        }
        Destroy(gameObject, 2);
       // Debug.Log("Shot down");
    }

}
