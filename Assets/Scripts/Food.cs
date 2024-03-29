using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int maxX = Screen.width - 50;
    private int maxY = Screen.height - 50;
    private Bounds bounds;
    private AudioSource _eatAudioSource;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private GameObject _particle;
    void Start()
    {
        bounds = bc.bounds;
        MoveToRandomPosition();
        this._eatAudioSource = GetComponent<AudioSource>();
    }

    private void MoveToRandomPosition()
    {
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        transform.position = new Vector3(x, y, 0.0f);
    }

    public void Hit()
    {
        _eatAudioSource.Play();
        Instantiate(this._particle, transform.position, Quaternion.identity);
        MoveToRandomPosition();
    }
    

}
