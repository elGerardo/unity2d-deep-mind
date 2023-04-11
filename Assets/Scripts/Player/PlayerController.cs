using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Diagnostics;
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
    public bool isDamaged = false;
  
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDamaged)
        {
            Horizontal = Input.GetAxisRaw("Horizontal") * Speed;

            if (Animator.GetBool("isAtacking") == false && Animator.GetBool("isDamaged") == false && Animator.GetBool("isJumping") == false)
            {
                Animator.SetBool("isWalking", Horizontal != 0.0f);
            }

            if (Horizontal < 0.0f) transform.localScale = new Vector3(-1f, 1.0f, 1.0f);
            else if (Horizontal > 0.0f) transform.localScale = new Vector3(1f, 1.0f, 1.0f);

            if (Input.GetKeyDown(KeyCode.W) && canJump && Animator.GetBool("isAtacking") == false)
            {
                Jump();
            }

            if(!canJump && Input.GetKeyDown("space"))
            {
                Debug.Log("jump atacin");
                Animator.SetBool("isAtacking", true);
                Animator.SetBool("isJumping", false);
                Animator.SetBool("isWalking", false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Animator.SetBool("isJumping", false);
        if (collision.gameObject.name == "UnderFloor" || 
            collision.gameObject.name == "HouseFloor" ||
            collision.gameObject.name == "SchoolFloor" ||
            collision.gameObject.name == "Pl1" ||
            collision.gameObject.name == "Pl2" ||
            collision.gameObject.name == "Pl3" ||
            collision.gameObject.name == "Pl4" ||
            collision.gameObject.name == "Pl5" ||
            collision.gameObject.name == "Pl6" ||
            collision.gameObject.name == "InFloor" ||
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
        Animator.SetBool("isJumping", true);
        Animator.SetBool("isWalking", false);
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        canJump = false;
    }
}
