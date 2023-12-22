using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    CharacterController _characterController;
    private Transform _player;
    // Start is called before the first frame update
    
    public float _moveSpeed = 5.0f;

    [SerializeField] private float _gravity = 2.0f;
    private float _yVelocity = 0.0f;
    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _player = playerGameObject.transform;

        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.position - transform.position;
        direction.Normalize();
        Vector3 velocity = direction * _moveSpeed;

        if (!_characterController.isGrounded)
        {
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
        _characterController.Move(velocity * Time.deltaTime);
    }
}
