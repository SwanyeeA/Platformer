using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            _animator.SetTrigger("Die");
            Destroy(gameObject, .5f);
        }
    }
}
