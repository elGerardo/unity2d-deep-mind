using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour
{
    public Transform controlAtack;
    public float radiousAtack;

    public float Speed;
    public float LineOfSite;
    public float DistanceCanAtack;
    private float timer;
    private float atackTimer;
    private bool movingRight;
    
    private bool playerCanBeAtacked;

    private Transform Player;
    private Animator Animator;

    public GameObject MainPlayer;
    private PlayerLife playerLife;

    [SerializeField]
    private PlayerController playerController;
    private EnemiesLife enemiesLife;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLife = GetComponent<EnemiesLife>();
        playerLife = FindObjectOfType<PlayerLife>();
        MainPlayer = GameObject.FindGameObjectWithTag("Player");
        Animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0f;
        atackTimer = 0f;
        playerCanBeAtacked = false;
        movingRight = true;
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
        if (!enemiesLife.isDamaged)
        {
            float DistanceFromPlayer = Vector2.Distance(transform.position, Player.position);

            if (DistanceFromPlayer < LineOfSite)
            {
                Animator.SetBool("isIdle", true);
                Animator.SetBool("isWalking", false);

                //change enemy direction
                Vector3 direction = MainPlayer.transform.position - transform.position;
                if (direction.x >= 0.0f) transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
                else transform.localScale = new Vector3(-1.5f, 1.5f, 1.0f);

                //validate atack or walk
                if (DistanceFromPlayer < DistanceCanAtack)
                {
                    Collider2D[] objects = Physics2D.OverlapCircleAll(controlAtack.position, radiousAtack);

                    foreach (Collider2D value in objects)
                    {

                        if (value.CompareTag("Player") && atackTimer >= 1.5 && !playerCanBeAtacked)
                        {
                            Debug.Log("is atacking...");
                            Animator.SetBool("isAtacking", true);
                            Animator.SetBool("isIdle", false);
                            playerCanBeAtacked = true;
                            atackTimer = 0f;
                        }

                        if (playerCanBeAtacked && atackTimer >= 0.3 && atackTimer < 0.415)
                        {
                            playerCanBeAtacked = false;
                            playerLife.TakeHit();
                        }

                        if (atackTimer >= 0.415)
                        {
                            Animator.SetBool("isIdle", true);
                            Animator.SetBool("isAtacking", false);
                        }
                    }

                }
                else
                {
                    playerCanBeAtacked = false;
                    Animator.SetBool("isIdle", true);
                    Animator.SetBool("isAtacking", false);
                    transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, Player.position.x, Speed * Time.deltaTime), transform.position.y);
                }
            }
            else
            {
                playerCanBeAtacked = false;
                Animator.SetBool("isIdle", false);
                Animator.SetBool("isWalking", true);
                Animator.SetBool("isAtacking", false);
                EnemyPatrol();
            }


            atackTimer += Time.deltaTime;

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOfSite);
        Gizmos.DrawWireSphere(transform.position, DistanceCanAtack);
        Gizmos.DrawWireSphere(controlAtack.position, radiousAtack);
    }
}
