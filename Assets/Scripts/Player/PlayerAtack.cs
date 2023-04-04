using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    public Transform controlHit;
    public float radiousHit;
    public float damageHit;
    private float timer;
    private bool canAtack;
    private Animator Animator;
    
    private void Start()
    {
        Animator = GetComponent<Animator>();
        canAtack = true;
        timer = 0f;
    }

    private void Update()
    {
    
        if (Input.GetKeyDown("space") && canAtack)
        {
            Animator.SetBool("isJumping", false);
            Animator.SetBool("isWalking", false);
            Animator.SetBool("isAtacking", true); 
            canAtack = false;
            timer = 0f;
            Hit();
        }

        if(!canAtack)
        {
            timer += Time.deltaTime; 
            if (timer >= 0.4)
            {
                canAtack = true;
                Animator.SetBool("isAtacking", false);
            }
        }

    }

    private void Hit()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(controlHit.position, radiousHit);

        foreach(Collider2D value in objects)
        {

            if (value.CompareTag("Enemy"))
            {
                Debug.Log("player hiting...");
                //value.transform.GetComponent<Enemy>().TakeHit(damageHit);
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(controlHit.position, radiousHit);
        Gizmos.DrawWireSphere(controlHit.position, damageHit);
    }
}
