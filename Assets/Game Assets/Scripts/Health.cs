using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maximumHealth = 100;
    private int _currentHealth;
    private Renderer _renderer;
    void Start()
    {
        _currentHealth = _maximumHealth;
        _renderer = GetComponentInChildren<Renderer>();
    }

    public override string ToString()
    {
        return _currentHealth + "/" + _maximumHealth;
    }

    public bool IsDead
    {
        get { return _currentHealth <= 0; }
    }

    public void Damage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            
        }

        if (_currentHealth==0)
        {
           
            Animation a = GetComponentInChildren<Animation>();
            a.Stop();
            Destroy(GetComponent<EnemyMovement>());
            Destroy(GetComponentInChildren<EnemyAttack>());
            
            
            EnemySpawnManager.OnEnemyDeath();
            
            
            Destroy(GetComponent<CharacterController>());
            Ragdoll r = GetComponent<Ragdoll>();
            if (r != null)
            {
                r.OnDeath();
                
            }
        }
    }

    void Update()
    {
        if (IsDead && !_renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }


}
