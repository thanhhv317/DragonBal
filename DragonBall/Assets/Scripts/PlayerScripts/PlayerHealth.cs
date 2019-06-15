using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth=100;
    public float currentHealth;
    public static PlayerHealth plhealth;
    public Slider PlayerHealthSlider;

    private void Awake()
    {
        if (plhealth == null)
        {
            plhealth = this;
        }
        else Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        PlayerHealthSlider.maxValue = maxHealth;
        PlayerHealthSlider.value = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        PlayerHealthSlider.value = currentHealth;

        if (currentHealth <= 0) makeDead();
    }
    void makeDead()
    {
        PlayerMovement.player.myAnim.SetBool("dead", true);
    }

}
