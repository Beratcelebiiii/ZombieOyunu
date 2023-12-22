using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    void Start()
    {
        DisableRagdoll();
    }
    void DisableRagdoll()
    {
        

        Rigidbody[] allRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var VARIABLE in allRigidbodies)
        {
            VARIABLE.isKinematic = true;
        }
    }

    void EnableRagdoll()
    {
        Rigidbody[] allRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var VARIABLE in allRigidbodies)
        {
            VARIABLE.isKinematic = false;
        }
    }

    public void OnDeath()
    {
        EnableRagdoll();
    }
}
