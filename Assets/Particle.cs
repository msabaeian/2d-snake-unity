using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        Invoke("DestroySelf", _particleSystem.main.duration);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
