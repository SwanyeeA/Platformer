using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    Animator _animator;

    public GameObject bulletPrefab;
    public Transform spawnPos;

    int speed = 10;
    int jumpForce = 800;
    int bulletForce = 100;

    public LayerMask groundLayer;

    public Transform FeetTrans;

    float groundCheckDist = .3f;

    bool grounded = false;

    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(FeetTrans.position, groundCheckDist, groundLayer);
        _animator.SetBool("Grounded", grounded);
    }


    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("Speed",Mathf.Abs(xSpeed));

        if(grounded && Input.GetButton("Jump"))
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }

        if(xSpeed > 0 && transform.localScale.x < 0 || xSpeed < 0 && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("Shoot");
            GameObject newBullet =  Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce * transform.localScale.x, 0));
        }

        
    }
}
