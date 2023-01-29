using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int deathCount = 0;
    [Header("Health")]
    [SerializeField] public float initialHealth = 10f;
    [SerializeField] public float maxHealth = 10f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;

    [Header("Sound Effects")]
    [SerializeField] private AudioSource dieSoundEffect;
    [SerializeField] private AudioSource damageSoundEffect;
    [SerializeField] private AudioSource reviveSoundEffect;

    [Header("Poison Settings")]
    [SerializeField] public int poisonDamage = 1;
    [SerializeField] public float damagetimer=10.0f;

    private Animator anim;

    private Character character;
    private CharacterController controller;
    private new Collider2D collider2D;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool StartGame = true;
  
    public float CurrentHealth { get; set; }

    [SerializeField] private float horizontalKnockback = 3000f;

    public void resetDeathCount()
    {
        deathCount = 0;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
        CurrentHealth = initialHealth;
        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth);
    }

    private void Start()
    {
        StartGame = true;
    }

    private void Update()
    {
        PoisonDamage();
    }

    private void PoisonDamage()
    {
        if (StartGame)
        {
            StartGame = false;
            damagetimer = 10.0f;
        }
        else
        {
            damagetimer -= Time.deltaTime;
        }
        if (damagetimer < 0)
        {
            TakeDamage(poisonDamage);
            damagetimer = 10.0f;
        }
    }
 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RockHead"))
        {
            TakeDamage(1);
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            TakeDamage(3);
        }

        if (other.gameObject.CompareTag("SpikeHead"))
        {
            TakeDamage(10);
        }

        if (other.gameObject.CompareTag("KnockbackTrap"))
        {
            TakeDamage(1);
            HandleKnockBack(other.gameObject);
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            TakeDamage(1);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {

        if (CurrentHealth < damage)
            CurrentHealth = 0;
        else
        {
            damageSoundEffect.Play();
            CurrentHealth -= damage;
        }

        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
        anim.SetTrigger("Damaged");
    }

    private void Die()
    {
        deathCount += 1;
        anim.SetTrigger("Death");
        if (character != null)
        {
            dieSoundEffect.Play();
            collider2D.enabled = false;
            character.enabled = false;
            controller.enabled = false;
        }

        if (destroyObject)
        {
            DestroyObject();
        }

    }
  
    public void Revive()
    {
        CurrentHealth = initialHealth;
        anim.SetTrigger("Revive");

        if (character != null)
        {
            collider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
        }

        gameObject.SetActive(true);

        reviveSoundEffect.Play();
        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth);
    }

    private void HandleKnockBack(GameObject pushingObject)
    {
        
        if (transform.position.x < pushingObject.transform.position.x)
        {
            rb.AddForce(Vector2.left * horizontalKnockback);
        }
        else
        {
            rb.AddForce(Vector2.right * horizontalKnockback);
        }
    }

    // If destroyObject is selected, we destroy this game object
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }

}
