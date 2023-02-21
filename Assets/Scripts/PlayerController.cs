using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float inputX;

    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    //private Animator Animator;
    private float Horizontal;
    private bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal") * Speed;

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.5f, 2.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.5f, 2.0f, 1.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
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
