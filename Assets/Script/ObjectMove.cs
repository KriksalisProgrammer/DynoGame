using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private float speed = 1.5f;
    private float leftBound = -15;
    private PlayerControl _playerControl;


    void Start()
    {
        _playerControl=GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    
    void Update()
    {
        if (_playerControl._Dead == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(transform.position.x <= leftBound && gameObject.CompareTag("Enemy"))
        {
           Destroy(gameObject);   
        }
    }
}
