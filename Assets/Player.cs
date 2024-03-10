using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _direction;
    private float speed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnMovement(InputValue value)
    {
        Vector2 newValue = value.Get<Vector2>();
        if (newValue is { x: 0, y: 0 } || (newValue.x != 0 && newValue.y != 0))
        {
            return;
        }
        _direction = newValue;
    }

    private void FixedUpdate()
    {
        rb.velocity = _direction * speed;
    }
}
