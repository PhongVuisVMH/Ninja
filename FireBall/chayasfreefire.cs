using UnityEngine;
public class chayasfreefire : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if (hit) return;
        //tốc độ hiện tại
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        //Nếu sống quá 5s thì tự hủy
        lifetime += Time.deltaTime;
        if (lifetime > 4) gameObject.SetActive(false);
    }

    //Kiểm tra để gây dame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        if (collision.tag == "Bocap")
        {
        //    collision.GetComponent<monster>().Damage(110);
            anim.SetTrigger("cham&no");
        }    
    }

    //Set hướng đi của đạn
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        //bật gameobject quả cầu lửa
        gameObject.SetActive(true);

        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
