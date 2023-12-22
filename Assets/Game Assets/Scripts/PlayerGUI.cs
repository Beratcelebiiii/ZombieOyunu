using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    [SerializeField]
    Texture2D _crosshair;

    private PlayerHealth _playerHealth;

    void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5,5,100,100),"Health:"+_playerHealth.ToString());
        float x = (Screen.width - _crosshair.width) / 2;
        float y = (Screen.height - _crosshair.height) / 2;
        GUI.DrawTexture(new Rect(x, y, _crosshair.width, _crosshair.height), _crosshair);
    } 
}
