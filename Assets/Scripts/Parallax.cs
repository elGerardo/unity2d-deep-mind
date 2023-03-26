using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float Speed;
    public float scaleX;
    public float scaleY;
    private float Horizontal;
    private Rigidbody2D Rigidbody2D;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal") * Speed;

        if (Horizontal < 0.0f) transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
}
