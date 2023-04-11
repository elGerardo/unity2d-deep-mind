using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemiesLife : MonoBehaviour
{
    public int lifes;
    public GameObject Enemy; // Referencia al objeto del jugador que se destruirá al perder todas las vidas
    private Animator animator;
    private float timer;
    public bool isDamaged;
    public bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes <= 0)
        {
            if(!isDead) timer = 0;

            isDead = true;

            animator.SetBool("isDie", true);
            if (timer >= 2) Destroy(Enemy);
            else timer += Time.deltaTime;
        
        }
        else
        {
            if (isDamaged) timer += Time.deltaTime;

            if (timer >= 0.3)
            {
                animator.SetBool("isDamaged", false);
                isDamaged = false;
                timer = 0;
            }
        }
    }

    public void TakeHit()
    {
        lifes -= 1;
        animator.SetBool("isDamaged", true);
        isDamaged = true;
        
    }
}
