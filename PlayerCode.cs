using System.Collections;
using SSystem.Collections.Generic;
using UnityEngine;


public class PlayerCode: MonoBehaviour
{
    int speed = 10;

    int jumpForce = 800;

    int bulletForce = 400;

    Rigidbody2D _rigidbody;

    public LayerMask groundLayer;

    public Transform spawnPos;

    Animator _animator;

    float groundCheckdist = .3f;

    bool grounded = false;

    void private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(FeetTrans.position, groundCheckdist, groundLayer);
        _animator.SetBool("Grounded", grounded);
    }

    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.setFloat("Speed", Mathf.Abs(xSpeed));

        if(Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(new Vector2(0,jumpForce));
        }

        if(xSpeed > 0 && transform.localScale.x < 0 || xSpeed < 0 && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1,0);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce * xSpeed, 0));
        }
    }
}