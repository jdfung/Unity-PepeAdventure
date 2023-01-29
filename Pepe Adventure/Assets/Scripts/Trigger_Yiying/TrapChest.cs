using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapChest : MonoBehaviour
{
    FlameThrower flameTraps;
    [SerializeField] private GameObject traps;
    private bool triggerTraps = false;
    private SpriteRenderer spriteRendChest;
    private bool isOnChest = false;

    private void Start()
    {
        flameTraps = traps.GetComponent<FlameThrower>(); 
        spriteRendChest = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(isOnChest && Input.GetKeyDown(KeyCode.LeftShift))
        {
            spriteRendChest.color = Color.red;
            StartCoroutine(CallTrap());
            spriteRendChest.color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D trapchest)
    {
        if(trapchest.transform.tag == "Player")
        {
            Debug.Log("Trigger Chest");
            isOnChest = true;

            /*spriteRendChest.color = Color.red;
            StartCoroutine(CallTrap());
            spriteRendChest.color = Color.white;*/
        }
    }

    private void OnTriggerExit2D(Collider2D trapchest)
    {
        if (trapchest.transform.tag == "Player")
        {
            isOnChest = false;
        }
    }


    private IEnumerator CallTrap()
    {
       triggerTraps = true;
       flameTraps.ActivateTraps(triggerTraps);
       yield return new WaitForSeconds(3);
       triggerTraps = false;
       flameTraps.DeactivateTraps(triggerTraps);
    }
}
