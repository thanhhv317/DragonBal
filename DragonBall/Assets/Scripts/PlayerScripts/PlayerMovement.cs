using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement player;


    //di chuyen
    public float speed = 10;
    public float jumpHight = 5;
    public bool facingRight;
    bool isGround;
    //---------

    // su dung skill tren mat dat
    public GameObject bullet;
    public Transform pos;
    //---------

    //su dung skill tren khong
    public GameObject bullet2;
    public Transform pos2;
    //---------

    //thoi gian hoi skill 
    public float timeQ;
    public float cooldown = 0.5f;
    public float timeRate = 0;

    //----------


    public Animator myAnim;
    public Rigidbody2D myBody;

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }
        else Destroy(gameObject);

        myAnim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
       
        //bat dau game thi nv no xoay mat ve ben phai
        facingRight = true;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        myBody.velocity = new Vector2(move * speed, myBody.velocity.y);
        myAnim.SetFloat("Run", Mathf.Abs(move));
        if(move>0 && !facingRight)
        {
            flip();
        }
        else if(move<0 && facingRight)
        {
            flip();
        }

        // ham nhay
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myAnim.SetBool("jump",true);
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHight);
            isGround = false;
        }
        if (Input.GetKey(KeyCode.DownArrow) && !isGround)
        {
            myAnim.SetBool("jumpdown", true);
            myBody.velocity = new Vector2(myBody.velocity.x, -1*jumpHight);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (timeRate <= Time.time)
            {
                timeRate = Time.time + cooldown;

                if (!isGround)
                {
                    myAnim.SetTrigger("attackInAir");
                    StartCoroutine(delay2(timeQ));
                }
                else if (Mathf.Abs(move) != 0)
                {
                    myAnim.SetTrigger("runAndAttack");
                }
                else
                {
                    myAnim.SetTrigger("attackInGround");
                    StartCoroutine(delay(timeQ));
                }               
            }
        }
    }

    // ham xoay mat
    void flip()
    {

        facingRight = !facingRight;
        Vector3 theSacle = transform.localScale;
        theSacle.x *= -1;
        transform.localScale = theSacle;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Ground"))
        {
            myAnim.SetBool("jump", false);
            myAnim.SetBool("jumpdown", false);
            isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Ground")
        {
            myBody.AddForce(new Vector2(transform.position.x, -500f));
        }

        if (target.tag == "Enemy")
        {
            PlayerHealth.plhealth.addDamage(2);
        }
    }

    IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(bullet, pos.position, Quaternion.identity);
    }
    IEnumerator delay2(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(bullet2, pos2.position, Quaternion.identity);
    }

}
