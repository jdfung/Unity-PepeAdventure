using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    [Header("Beartrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    Health playerHealth;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered = false;//when trap is triggered
    private bool active = false; //when trap is activated

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D beartrap)
    {
        if (beartrap.tag == "Player")
        {
            if (!triggered)
            {
                //trigger the trap
                StartCoroutine(ActivateBearTrap());
            }
            if (active)
            {
                playerHealth.TakeDamage(damage);
                
            }
        }
    }

    private IEnumerator ActivateBearTrap()
    {
        triggered = true;
        spriteRend.color = Color.red; //turn the sprite to red to notify the player

        //Wait for delay,activate trap, turn on animation, return color to original 
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //turn the sprite back to original form
        active = true;
        anim.SetBool("activated", true);
        
        //Wait until X seconds, deactivate trap and reset all the variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
