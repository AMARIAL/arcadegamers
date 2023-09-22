using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private Camera _cam;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 100.0f;
    [SerializeField] private Vector3 _camOffset;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _cam = Camera.main;
        _direction = (_cam.ScreenToWorldPoint(Input.mousePosition) + _camOffset - transform.position).normalized;
        _rb.AddForce(_direction * _speed);
    }

    private void FixedUpdate()
    {
        if(transform.position.y > 10.0f)
            Destroy(gameObject);
    }
}
