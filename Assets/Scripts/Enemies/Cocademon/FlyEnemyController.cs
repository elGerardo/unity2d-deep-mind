using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyController : MonoBehaviour
{
    public float Speed;
    public float LineOfSite;

    public SpriteRenderer bossRenderer;
    public Color attackColor;
    public float fireRate = 1f;
    private float nextFireTime;
    public float ShootingRange;
    public GameObject Bullet;
    public GameObject BulletParent;

    private Transform Player;
    private Animator Animator;
    public GameObject MainPlayer;

    // Start is called before the first frame update
    void Start()
    {
        MainPlayer = GameObject.FindGameObjectWithTag("Player");
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceFromPlayer = Vector2.Distance(Player.position, transform.position);
        if (DistanceFromPlayer < LineOfSite && DistanceFromPlayer > ShootingRange && !Animator.GetBool("isDie"))
        {
            Vector3 direction = MainPlayer.transform.position - transform.position;
            if (direction.x >= 0.0f) transform.localScale = new Vector3(2.5f, 2.5f, 1.0f);
            else transform.localScale = new Vector3(-2.5f, 2.5f, 1.0f);

            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, Speed * Time.deltaTime);
        }
        else if (DistanceFromPlayer <= ShootingRange && nextFireTime < Time.time)
        {
            Animator.SetBool("isAtacking", true);
            Instantiate(Bullet, BulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;

        }
        else
        {
            Animator.SetBool("isAtacking", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOfSite);
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
}
