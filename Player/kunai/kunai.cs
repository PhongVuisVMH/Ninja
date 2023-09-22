using UnityEngine;
public class kunai : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ninja")
        {
            shoot.canshoot = true;
            Destroy(gameObject);
        }
    }
}
