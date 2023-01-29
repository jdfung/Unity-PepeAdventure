using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    [Header("Firetrap Settings")]
    [SerializeField] private float coolDownTime;
    [SerializeField] private float activeTime;
    [SerializeField] private float DelayTime;
    [SerializeField] private bool trapactive = true;// = false;

    Health playerHealth; 
    private Animator anim;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        StartCoroutine(DelayTrap());
    }

    // Update is called once per frame
    void Update()
    {
        if(!trapactive)
        {
            StartCoroutine(FiretrapActive());
        }
        else
        {
            StartCoroutine(FiretrapDeactive());
        }
        
    }

    private void OnTriggerEnter2D(Collider2D firetrap)
    {
        if(firetrap.tag == "Player")
        {
            if(!trapactive)
            {
                return;
            }
                playerHealth.TakeDamage(damage);
        }
    }
    
    private IEnumerator DelayTrap()
    {
        yield return new WaitForSeconds(DelayTime);
    }

    private IEnumerator FiretrapActive()
    {
            yield return new WaitForSeconds(coolDownTime);//2secs
            trapactive = true;
            anim.SetBool("activated", true); 
    }

    private IEnumerator FiretrapDeactive()
    {
        yield return new WaitForSeconds(activeTime);
        trapactive = false;
        //triggered = false;
        anim.SetBool("activated", false);
    }
}
