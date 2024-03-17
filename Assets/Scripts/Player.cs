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
    private List<Transform> parts;
    private AudioSource _bgAudioSource;
    [SerializeField] private Transform snakePartPrefab;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        food = FindObjectOfType<Food>();
        wallLayer = LayerMask.NameToLayer("Wall");
        parts = new List<Transform>();
        parts.Add(transform);
        _bgAudioSource = GetComponent<AudioSource>();
        _bgAudioSource.Play();
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
        for (int i = parts.Count - 1; i > 0; i--)
        {
            parts[i].position = parts[i - 1].position;
        }
        

        rb.velocity = _direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == food.gameObject.layer)
        {
            score += 1;
            scoreText.text = $"Score: {score}";
            Transform newPart = Instantiate(snakePartPrefab);
            newPart.position = parts[parts.Count - 1].position;
            parts.Add(newPart);
            food.Hit();
        }else if (other.gameObject.layer == wallLayer)
        {
            SceneManager.LoadScene("Scenes/Game");
        }
    }
}
