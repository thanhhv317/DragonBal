using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour {
    public float speed = 12f;
    Rigidbody2D myBody;
    bool tmp;
    public GameObject effect;
    public Transform pos;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        tmp = EnemyBlack.Enemy.facingRight;
        if (tmp)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else
        {
            transform.Rotate(0, 180, 0);
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Instantiate(effect, pos.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
