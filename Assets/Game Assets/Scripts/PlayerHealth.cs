using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maximumHealth = 100;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = _maximumHealth;
    }

    public override string ToString()
    {
        return _currentHealth + "/" + _maximumHealth;
    }

    public bool IsDead
    {
        get { return _currentHealth <= 0; }
    }

    public void PlayerDamage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;

        }

        if (_currentHealth == 0)
        {
            Animator a = GetComponentInChildren<Animator>();
            Destroy(a);
            Destroy(GetComponent<PlayerMovement>());
            Destroy(GetComponent<PlayerAnimation>());
            Destroy(GetComponent<RifleWeapon>());
            Destroy(GetComponent<CharacterController>());
           
            
            Ragdoll r = GetComponent<Ragdoll>();
            if (r != null)
            {
                r.OnDeath();
                Destroy(this.gameObject, 1);
            }
        }
    }


}