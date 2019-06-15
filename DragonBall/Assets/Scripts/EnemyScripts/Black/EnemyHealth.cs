using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth=100;
    float currentHealth;
    public static EnemyHealth enmHealth;

    public Slider EnemyHealthSlider;


    private void Awake()
    {
        if (enmHealth == null)
        {
            enmHealth = this;
        }
        else Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        EnemyHealthSlider.maxValue = maxHealth;
        EnemyHealthSlider.value = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        EnemyHealthSlider.value = currentHealth;

        if (currentHealth <= 0) makeDead();
    }
    void makeDead()
    {
        EnemyBlack.Enemy.myAnim.SetBool("dead", true);
        Destroy(gameObject, 2f);
    }
}
