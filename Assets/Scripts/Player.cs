using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private float speed = 5f;
    private Rigidbody2D rb;
    private Food food;
    private int score = 0;
    private int wallLayer;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        food = FindObjectOfType<Food>();
        wallLayer = LayerMask.NameToLayer("Wall");
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == food.gameObject.layer)
        {
            score += 1;
            scoreText.text = $"Score: {score}";
            food.MoveToRandomPosition();
        }else if (other.gameObject.layer == wallLayer)
        {
            SceneManager.LoadScene("Scenes/Game");
        }
    }
}
