using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour

{
    public int speed = 2;
    public float lookDist = 6;
    Rigidbody2D _rigidbody;
    Animator _animator;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveLoop());

    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);

            if (Vector2.Distance(transform.position, player.position) < lookDist)
            {
                if (player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
                {
                    transform.localScale *= new Vector2(-1, 1);
                }

                Vector2 dir = (player.position - transform.position);
                // give us the angle that we want 
                _rigidbody.velocity = dir.normalized * speed;

            }
            else
            {
                _rigidbody.velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            
            Destroy(other.gameObject);
            
            Destroy(gameObject);
        }
    }


}
