using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruit : MonoBehaviour
{
    //private float fruitnum = 0; //number of fruits we want
    //private Character playableCharacter;
    [SerializeField] private int healpoint = 1;
    [SerializeField] private AudioSource collectionSoundEffects;
    Health playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
    }

    //connect the player with the coin
    private void OnTriggerEnter2D(Collider2D fruit)
    {
        if (fruit.transform.tag == "Fruit")
        {
            if (playerHealth.CurrentHealth == playerHealth.maxHealth)
            {
                return;
            }
            collectionSoundEffects.Play();
            fruit.gameObject.SetActive(false);
            playerHealth.CurrentHealth += healpoint;
            UIManager.Instance.UpdateHealth(playerHealth.CurrentHealth, playerHealth.maxHealth);
        }
    }
}
