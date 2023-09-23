using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 100.0f;
    public Transform Aim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _direction = (Aim.position - transform.position).normalized;
        _rb.AddForce(_direction * _speed);
    }

    private void FixedUpdate()
    {
        if(transform.position.y > 10.0f)
            Destroy(gameObject);
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Egg"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Egg>().Hit(10);
        }
    }
}
