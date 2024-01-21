using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isRun = false;
    private bool isJumping = false;
    private bool canDoubleJump = false;
    public bool isGround = true;
    public bool canRun = true;
    public float jumpForce = 10f;
    public float moveSpeed = 6f;
    public int countCherry = 0;
    public ThanhHP thanhHP;
    public int hpNow;
    public int hpMax = 3;

    public TextMeshProUGUI txtCherry;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.tag + " - OnCollisionEnter2D");
        if (other.gameObject.tag == "ground")
        {
            isGround = true;
            canRun = true;
        }

        if(other.gameObject.tag == "door"){
            SceneManager.LoadScene("LV2");
        }

        if(other.gameObject.tag == "obstacle"){
            afterColliderCrash();
        }

        if(other.gameObject.tag == "cherry"){
            Destroy(other.gameObject);
            countCherry ++;
            txtCherry.SetText("" + countCherry);
        }
    }

    void Start()
    {
        hpNow = hpMax;
        thanhHP.trangThaiThanhSinhMenh(hpNow,hpMax);
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            canDoubleJump = false;
        }

        float movePrefix = Input.GetAxisRaw("Horizontal");
        // transform.position += new Vector3(movePrefix * Time.deltaTime * moveSpeed, 0f, 0f); // run
        rigidbody2D.velocity = new Vector2(movePrefix * moveSpeed,rigidbody2D.velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning",true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning",true);
        }

        if(movePrefix == 0){
            animator.SetBool("isRunning",false);
        }else{

        }

        if(movePrefix < 0){
            // spriteRenderer.flipX = true;
            transform.eulerAngles = new Vector3(0,180,0);
        }else if(movePrefix > 0){
            // spriteRenderer.flipX = false;
            transform.eulerAngles = new Vector3(0,0,0);
        }
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if (thanhHP != null) DontDestroyOnLoad(thanhHP.gameObject);
        if (txtCherry != null) DontDestroyOnLoad(txtCherry.gameObject);
    }

        void Jump()
    {
        // rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        rigidbody2D.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        animator.SetTrigger("canJump");
        isGround = false;
        canDoubleJump = true;
    }

    void afterColliderCrash(){
        hpNow -= 1;
        thanhHP.trangThaiThanhSinhMenh(hpNow,hpMax);
        if(hpNow <= 0){
            Destroy(gameObject);
        }
    }
}
