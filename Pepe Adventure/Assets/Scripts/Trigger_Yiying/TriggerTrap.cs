using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    Health playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
    }

    //connect the player with the coin
    private void OnTriggerEnter2D(Collider2D traps)
    {
        if (traps.transform.tag == "Player")
        {
            /*if (playerHealth.CurrentHealth == playerHealth.maxHealth)
            {
                return;
            }*/
            // Destroy(fruit.gameObject);

            playerHealth.TakeDamage(damage);
            //UIManager.Instance.UpdateHealth(playerHealth.CurrentHealth, playerHealth.maxHealth);
        }
    }
}
