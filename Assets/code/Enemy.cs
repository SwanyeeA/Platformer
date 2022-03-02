using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy: MonoBehaviour
{

    public GameObject explosion;
    Animator _animator;  
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _animator.SetTrigger("Die");
            Destroy(gameObject, .5f);
        }
    }

    void Update()
    {
        
    }

}