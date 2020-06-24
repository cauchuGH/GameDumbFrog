using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject obj; 

    public float speedPlayer;
    public float maxSpeedPlayer;
    public float jumpPower;
    public float maxJump;
    public bool doubleJump;
    public float acceleration; // tu nay dich ra la gia toc, tang speed len 1/10000 moi lan update

    public Rigidbody2D rb;

    public GameObject gameController;

    public bool inGlass;
    bool checkPush = false; // liem tra co phai bi Glass day ra ngoai

    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;

        speedPlayer = 3f;
        maxSpeedPlayer = 5f;
        jumpPower = 4500f;
        maxJump = 6000f;
        doubleJump = true;
        acceleration = 1.0001f;

        gameController = GameObject.FindGameObjectWithTag("GameController");

        Anim = obj.GetComponent<Animator>();
        Anim.SetBool("checkJump", false); 
    }

    // Update is called once per frame
    void Update()
    {
        // tang kha nang nhay theo thoi gian
        Acceleration(ref jumpPower, ref maxJump);
        // tang toc theo thoi gian
        Acceleration(ref speedPlayer, ref maxSpeedPlayer);
    }
    private void FixedUpdate()
    {   
        // huy xoay nguoi sau khi nhay lan 2
        if(inGlass == true)
        {
            Anim.SetBool("checkJump", false);
        }

        // di chuyen trai phai nhay
        MovePlayer();
        // kiem tra bi glass day ra ngoai chet
        DeadOut();
    }

    void Acceleration(ref float sp, ref float maxSp)
    {
        if (sp >= maxSp)
        {
            sp = maxSp;
        }
        else
        {
            sp = sp * acceleration;
        }
    }
    void MovePlayer()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            obj.transform.Translate(new Vector3(-speedPlayer * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            obj.transform.Translate(new Vector3(speedPlayer * Time.deltaTime, 0, 0));           
        }

        // jump
        if (Input.GetKeyDown(KeyCode.W)) // 
        {           
            if (inGlass == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector3.up * jumpPower);
            }
            else if(doubleJump == true)
            {
                Anim.SetBool("checkJump", true); // xoay nguoi
                doubleJump = false;
                rb.velocity = new Vector2(rb.velocity.x, 0);// khong dat velocity.y ve 0 no se cong don 2 lan nhay
                rb.AddForce(Vector3.up * 0.5f * jumpPower);
            }      
        }
    }

    void DeadOut()
    {
        if (checkPush == true && transform.position.x < -9.1)
        {
            gameController.GetComponent<GameController>().EndGame();
        }
    }
    // ham Trigger kiem tra player co bi glass day hay ko
    void OnTriggerStay2D(Collider2D other)
    {
        checkPush = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        checkPush = false;
    }

    // kiem tra player khi bi roi xuong vuc
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Fall")
        {
            gameController.GetComponent<GameController>().EndGame();
        }
    }
}
