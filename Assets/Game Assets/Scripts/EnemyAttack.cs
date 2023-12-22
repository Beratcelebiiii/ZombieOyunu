using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float _nextTimeAttackIsAllowed = -1.0f;
    [SerializeField]
    float _attackDelay=1.0f;

    [SerializeField] 
    private int _damageDealt = 5;
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player" && Time.time>=_nextTimeAttackIsAllowed)
        {
            PlayerHealth _plaHealth = other.GetComponent<PlayerHealth>();
            _plaHealth.PlayerDamage(_damageDealt);
            _nextTimeAttackIsAllowed = Time.time+_attackDelay;
        }
    }
}
