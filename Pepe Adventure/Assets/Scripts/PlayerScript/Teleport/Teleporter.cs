using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
