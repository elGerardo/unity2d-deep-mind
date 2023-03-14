using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float inputX;

    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool canJump;

    public bool isDamaged;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        isDamaged = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(isDamaged)
        {
            Animator.SetBool("isDamaged", true);
        }
        else
        {
            Animator.SetBool("isDamaged", false);
            Horizontal = Input.GetAxisRaw("Horizontal") * Speed;

            if (Horizontal < 0.0f) transform.localScale = new Vector3(-1f, 1.0f, 1.0f);
            else if (Horizontal > 0.0f) transform.localScale = new Vector3(1f, 1.0f, 1.0f);

            if (Input.GetKeyDown(KeyCode.W) && canJump)
            {
                Jump();
                canJump = false;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "UnderFloor" || 
            collision.gameObject.name == "HouseFloor" || 
            collision.gameObject.name == "OutFloor")
        {
            canJump = true;
        }
    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
}
