using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    public GameObject bullet;
    private PlayerLife playerLife;
    private float timerAtacked;

    [SerializeField]
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //FindObjectOfType<PlayerController>().isDamaged = true;
            playerLife.lifes -= 1;
            timerAtacked = 0;
        }
    }

    void Update()
    {
        if (timerAtacked >= 0.5)
        {
            //FindObjectOfType<PlayerController>().isDamaged = false;
        }
        else
        {
            timerAtacked += Time.deltaTime;
        }
    }
}
