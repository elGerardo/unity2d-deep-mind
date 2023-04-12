using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    private PlayerLife playerLife;
    public bool canMove;
    public float Speed;
    public float Limit;
    private float timer;
    private bool movingRight;

    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
    }

    void Patrol()
    {
        if (timer >= Limit)
        {
            movingRight = !movingRight;
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (movingRight)
        {
            //transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else
        {
            //transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }

    void Update()
    {
        if(canMove)
        {
            Patrol();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerLife.TakeHit();
        }
    }
}
