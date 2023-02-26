using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour
{
    public float Speed;
    public float LineOfSite;
    public float DistanceCanAtack;
    private float timer;
    private bool movingRight;

    private Transform Player;
    private Animator Animator;

    public GameObject MainPlayer;

    // Start is called before the first frame update
    void Start()
    {
        MainPlayer = GameObject.FindGameObjectWithTag("Player");
        Animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0f;
        movingRight = true;
       // InvokeRepeating("Patrol", 0f, Time.deltaTime);
    }

    // Update is called once per frame
    void EnemyPatrol()
    {
        if(timer >= 3)
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
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }
    void Update()
    {
        float DistanceFromPlayer = Vector2.Distance(transform.position, Player.position);
        if (DistanceFromPlayer < LineOfSite)
        {

            Vector3 direction = MainPlayer.transform.position - transform.position;
            if (direction.x >= 0.0f) transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
            else transform.localScale = new Vector3(-1.5f, 1.5f, 1.0f); 

            if (DistanceFromPlayer < DistanceCanAtack)
            {
                Animator.SetBool("isAtacking", true);
            }
            else
            {
                Animator.SetBool("isAtacking", false);
                transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, Player.position.x, Speed * Time.deltaTime), transform.position.y);
            }
            //transform.position = Vector2.MoveTowards(this.transform.position, Player.position, Speed * Time.deltaTime);
        }
        else
        {
            Animator.SetBool("isAtacking", false);
            EnemyPatrol();
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOfSite);
        Gizmos.DrawWireSphere(transform.position, DistanceCanAtack);
    }
}
