using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour {

    public float speed = 10f;
    public GameObject effect;
    public Transform pos;

    Rigidbody2D mybody;
    bool tmp;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        tmp = PlayerMovement.player.facingRight;
        if (tmp)
        {
            mybody.velocity = new Vector2(speed, -speed);
        }
        else
        {
            transform.Rotate(0, 180, 0);
            mybody.velocity = new Vector2(-speed, -speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            EnemyHealth.enmHealth.addDamage(10);
            Instantiate(effect, pos.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
