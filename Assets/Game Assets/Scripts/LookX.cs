using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    float _sensitivity = 5.0f;

    float _mouseX = 0.0f;
   

    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");

        Vector3 rot = transform.localEulerAngles;
        rot.y += _mouseX * _sensitivity;
        transform.localEulerAngles = rot;
    }
}
