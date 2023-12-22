using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private static int _livingZombies = 0;

    static public void OnEnemyDeath()
    {
        --_livingZombies;
    }

    [SerializeField] 
    private int _enemyLimit = 30;
    [SerializeField]
    GameObject _enemyToSpawn;
    [SerializeField]
    float _spawnDelay = 1.0f;

    private float _nextSpawnTime = -1.0f;
    [SerializeField] 
    private LayerMask _spawnLayer;
    void Update()
    {
        if (Time.time >= _nextSpawnTime && _livingZombies<_enemyLimit)
        {
            Vector3 edgeOfScreen = new Vector3(1.25f, Random.value, 8.0f);
            if (Random.value>0.5f)
            {
                edgeOfScreen.x = -0.25f;
            }
            Ray ray = Camera.main.ViewportPointToRay(edgeOfScreen);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, Mathf.Infinity,_spawnLayer.value))
            {
                Vector3 placeToSpawn = hit.point;
                Quaternion directionToFace = Quaternion.identity;
                Instantiate(_enemyToSpawn, placeToSpawn, directionToFace);
                _nextSpawnTime = Time.time + _spawnDelay;
                ++_livingZombies;
            }
           
        }

        
    } 
}
