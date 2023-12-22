using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _animator.SetFloat("Horizontal",h);
        _animator.SetFloat("Vertical",v);

        if (!Mathf.Approximately(h, 0f) || !Mathf.Approximately(v, 0f))
        {
            
            _animator.SetBool("Motion",true);
        }
        else
        {
            _animator.SetBool("Motion",false);
        }
    }
}
