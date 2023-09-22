using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public bool quaitrai = true; //quay mặt sang phải
    Rigidbody2D player;
    public float jump = 8f;
    public LayerMask groundLayer;
    public bool grounded = false; //va cham voi mat dat
    public Transform Sensor; //Check vi tri de nhay
    //int numberOfJump = 0;

    Animator playerAnim; //animation 
    bool isJumping = true;
    bool isDeath = false;
    public static PlayerController instance;
    public float ControlButtons;
    AudioManager audioManager;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if(instance == this) Destroy(gameObject);
        
        if(Write.instance == null) return;
        
        else Write.instance.connection();
    }

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        //isJumping = false;

    }

    private void Update()
    {
        PlayerMove();
        Jump();
        Death();
    }
   
    //di chuyển
    public void PlayerMove()
    {
        //audioManager.PlayAudioClip(audioManager.)
        playerAnim.SetFloat("Run", Mathf.Abs(ControlButtons));
        ControlButtons = Input.GetAxis("Horizontal");// khởi tạo nút điều khiển di chuyển ngang
        transform.position += Vector3.right * ControlButtons * speed * Time.deltaTime;

        if (ControlButtons > 0 && quaitrai == false)
        {
            Flip();
        }
        else if (ControlButtons < 0 && quaitrai == true)
        {
            Flip();

        }
    }

    public void Jump()
    {
        playerAnim.SetBool("Jump", isJumping);
        grounded = Physics2D.OverlapCircle(Sensor.position, 0.1f, groundLayer);
        isJumping = false;
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            audioManager.PlayAudioClip(audioManager.Jump);
            player.velocity = new Vector2(player.velocity.x, jump);
            isJumping = true;
            //musicPlayer.PlayOneShot(jumpmusic);
        }
    }
    public void Flip()
    {
        quaitrai = !quaitrai;
        Vector3 phiatruoc = transform.localScale;
        phiatruoc.x *= -1;
        transform.localScale = phiatruoc;
    }
  
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            audioManager.PlayAudioClip(audioManager.Coins);
        }
    }

    public void Death()
    {
        if (transform.position.y < -9f && !isDeath)
        {
            audioManager.PlayAudioClip(audioManager.Death);
            isDeath = true;
            GameManager.Instance.Death();
            if (Write.instance == null) return;
            Write.instance.sendInfo();
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Sensor.position, 0.1f);
    }
}
