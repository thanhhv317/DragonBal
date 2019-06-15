using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComboAttack : MonoBehaviour {
    Rigidbody2D myBody;
    Animator anim;
    //chieu 1---
    public Transform posCombo;
    public float atkSpeed=10f;

    float timeR = 0, coolDown = 2f;
    //--------

    //chieu 2-------------
    public Transform posCombo2;
    float timeR2 = 1;



    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (Time.time>timeR)
            {
                timeR = Time.time + coolDown;
                StartCoroutine(combo1(2f));
            }
            if (Time.time > timeR2)
            {
                timeR2 = Time.time + coolDown;
                StartCoroutine(combo2(2f));
            }
            StartCoroutine(gravity(2f));      
        }
    }

    IEnumerator combo1(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = posCombo.position;
        myBody.gravityScale = 0;
        anim.SetTrigger("combo");
        PlayerMovement.player.myAnim.SetTrigger("damage");
        if (EnemyBlack.Enemy.facingRight == true)
        {
            if (PlayerMovement.player.facingRight == true)
            {
                myBody.velocity = new Vector2(atkSpeed, PlayerMovement.player.transform.position.y);
                PlayerMovement.player.myBody.AddForce(new Vector2(700f,transform.position.y ));
            }
            if(PlayerMovement.player.facingRight==false)
            {
                EnemyBlack.Enemy.flip();
                myBody.velocity = new Vector2(-atkSpeed, PlayerMovement.player.transform.position.y);
                PlayerMovement.player.myBody.AddForce(new Vector2(-700f, transform.position.y));
            }
        }
        else
        {
            if (PlayerMovement.player.facingRight == true)
            {
                EnemyBlack.Enemy.flip();
                myBody.velocity = new Vector2(atkSpeed, PlayerMovement.player.transform.position.y);
                PlayerMovement.player.myBody.AddForce(new Vector2(700f, transform.position.y));
            }
            else
            {
                myBody.velocity = new Vector2(-atkSpeed, PlayerMovement.player.transform.position.y);
                PlayerMovement.player.myBody.AddForce(new Vector2(-700f, transform.position.y));
            }
        }
    }

    IEnumerator combo2(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = posCombo2.position;
        myBody.gravityScale = 0;
        anim.SetTrigger("combo2");
        PlayerMovement.player.myAnim.SetTrigger("damage");
        if (EnemyBlack.Enemy.facingRight == true)
        {
            if (PlayerMovement.player.facingRight == true)
            {
                EnemyBlack.Enemy.flip();
                myBody.velocity = new Vector2(-atkSpeed, PlayerMovement.player.transform.position.y);
                PlayerMovement.player.myBody.AddForce(new Vector2(-700f, transform.position.y));
            }
            if (PlayerMovement.player.facingRight == false)
            {
                myBody.velocity = new Vector2(atkSpeed, PlayerMovement.player.transform.position.y);
                PlayerMovement.player.myBody.AddForce(new Vector2(700f, transform.position.y));
            }
        }
        else
        {
            if (PlayerMovement.player.facingRight == true)
            {
                
                myBody.velocity = new Vector2(-atkSpeed, PlayerMovement.player.transform.position.y);
                PlayerMovement.player.myBody.AddForce(new Vector2(-700f, transform.position.y));
            }
            else
            {
                EnemyBlack.Enemy.flip();
                myBody.velocity = new Vector2(atkSpeed, PlayerMovement.player.transform.position.y);
                PlayerMovement.player.myBody.AddForce(new Vector2(700f, transform.position.y));
            }
        }
    }

    IEnumerator gravity(float time)
    {
        yield return new WaitForSeconds(time);
        myBody.gravityScale = 3;
    }

}
