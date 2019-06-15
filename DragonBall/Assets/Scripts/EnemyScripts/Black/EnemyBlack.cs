using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlack : MonoBehaviour {
    
    Rigidbody2D myBody;
    public Animator myAnim;
    public float timeRate=0, timeDown=3f;
    public float kCach = 4f;

    public static EnemyBlack Enemy;

    
    public bool facingRight;
    //ban dan
    public float timeF;
    public GameObject bullet3;
    public Transform pos;
    //---------
   
    private void Awake()
    {

        if (Enemy == null)
        {
            Enemy = this;
        }
        else Destroy(gameObject);

        myAnim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        facingRight =true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //facingRight = PlayerMovement.player.facingRight;
        if (timeRate < Time.time)
        {
            timeRate = Time.time + timeDown;
            myAnim.SetTrigger("tele");
            myBody.gravityScale = 0;
            //if (PlayerMovement.player.facingRight  )
            //{

            //    transform.position = new Vector2(PlayerMovement.player.transform.position.x - kCach, PlayerMovement.player.transform.position.y);
            //    StartCoroutine(delay(timeF));
            //}
            //else if (PlayerMovement.player.facingRight && !facingRight)
            //{
            //    flip();
            //    transform.position = new Vector2(PlayerMovement.player.transform.position.x - kCach, PlayerMovement.player.transform.position.y);
            //    StartCoroutine(delay(timeF));
            //}
            //else if (!PlayerMovement.player.facingRight && facingRight)
            //{
            //    flip();
            //    transform.position = new Vector2(PlayerMovement.player.transform.position.x + kCach, PlayerMovement.player.transform.position.y);
            //    StartCoroutine(delay(timeF));
            //}
            //else if (!PlayerMovement.player.facingRight && !facingRight)
            //{
            //    flip();
            //    transform.position = new Vector2(PlayerMovement.player.transform.position.x + kCach, PlayerMovement.player.transform.position.y);
            //    StartCoroutine(delay(timeF));
            //}
            //StartCoroutine(gravity(2f));

            // lan 2 thu code

            if (PlayerMovement.player.facingRight == facingRight) // ko doi dien
            {
                if(PlayerMovement.player.transform.position.x > transform.position.x)
                {
                    if (facingRight = true)
                    {
                       
                        transform.position = new Vector2(PlayerMovement.player.transform.position.x + kCach, PlayerMovement.player.transform.position.y);
                        StartCoroutine(delay(timeF));
                    }
                    else
                    {
                        transform.position = new Vector2(PlayerMovement.player.transform.position.x - kCach, PlayerMovement.player.transform.position.y);
                        StartCoroutine(delay(timeF));
                    }
                }
                if (PlayerMovement.player.transform.position.x < transform.position.x)
                {
                    if (facingRight = true)
                    {

                        transform.position = new Vector2(PlayerMovement.player.transform.position.x - kCach, PlayerMovement.player.transform.position.y);
                        StartCoroutine(delay(timeF));

                    }
                    else
                    {

                        transform.position = new Vector2(PlayerMovement.player.transform.position.x + kCach, PlayerMovement.player.transform.position.y);
                        StartCoroutine(delay(timeF));

                    }
                }

            }
            if (PlayerMovement.player.facingRight != facingRight ) // doi dien nhau
            {
                // Player dung truoc enemy
                if( PlayerMovement.player.transform.position.x >= transform.position.x)
                {
                    if(facingRight = true)
                    {

                        flip();
                        transform.position = new Vector2(PlayerMovement.player.transform.position.x + kCach, PlayerMovement.player.transform.position.y);
                        StartCoroutine(delay(timeF));
                    }
                    if(facingRight=false)
                    {

                        flip();
                        transform.position = new Vector2(PlayerMovement.player.transform.position.x - kCach, PlayerMovement.player.transform.position.y);
                        StartCoroutine(delay(timeF));
                    }
                }
                else if(PlayerMovement.player.transform.position.x < transform.position.x)
                {
                    flip();
                    transform.position = new Vector2(PlayerMovement.player.transform.position.x - kCach, PlayerMovement.player.transform.position.y);
                    StartCoroutine(delay(timeF));
                }


            }
            StartCoroutine(gravity(2f));

        }


    }

    IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(bullet3, pos.position, Quaternion.identity);
        
    }

    public void flip()
    {
        facingRight = !facingRight;
        Vector3 theSacle = transform.localScale;
        theSacle.x *= -1;
        transform.localScale = theSacle;
    }
    IEnumerator gravity(float time)
    {
        yield return new WaitForSeconds(time);
        myBody.gravityScale = 3;
    }


}
