using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] private int damage;
    Health playerHealth;
    private Animator anim;
    private SpriteRenderer spriteRendFlame;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        anim = GetComponent<Animator>();
        spriteRendFlame = GetComponent<SpriteRenderer>();
    
    }

    public void ActivateTraps(bool triggered)
    {
        Debug.Log("Actviate Flame");
        Debug.Log(triggered);
        if (!triggered)
        {
            return;
        }
        anim.SetBool("activate", true);
        playerHealth.TakeDamage(damage);
    } 

    public void DeactivateTraps(bool triggered)
    {
        Debug.Log("Deactivate Flame");
        Debug.Log(triggered);
        if (triggered)
        {
            return;
        }
        anim.SetBool("activate", false);
    }
}
