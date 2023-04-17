using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class PlayerLife : MonoBehaviour
{
    public int lifes;
    public bool isDamaged;
    public GameObject Player; 
    private Animator animator;
    private float timer;
    private PlayerController playerController;
    public GameObject life0;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

        life0.SetActive(false);
        life1.SetActive(false);
        life2.SetActive(false);
        life3.SetActive(false);
        life4.SetActive(false);
        life5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes >= 1)
        {

            if (isDamaged) timer += Time.deltaTime;

            if (timer >= 0.5)
            {
                animator.SetBool("isDamaged", false);
                isDamaged = false;
                playerController.isDamaged = false;
                timer = 0;
            }

            if (lifes >= 5)
            {
                life0.SetActive(true);
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(false);
            }
            if (lifes == 4)
            {
                life0.SetActive(false);
                life1.SetActive(true);
                life2.SetActive(false);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(false);
            }
            if (lifes == 3)
            {
                life0.SetActive(false);
                life1.SetActive(false);
                life2.SetActive(true);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(false);
            }
            if (lifes == 2)
            {
                life0.SetActive(false);
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(true);
                life4.SetActive(false);
                life5.SetActive(false);
            }
            if (lifes == 1)
            {
                life0.SetActive(false);
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                life4.SetActive(true);
                life5.SetActive(false);
            }
        }

    }

    public void TakeHit()
    {
        lifes -= 1;
        if(lifes <= 0)
        {

            life0.SetActive(false);
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
            life4.SetActive(false);
            life5.SetActive(true);

            animator.SetBool("isAtacking", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isDamaged", false);
            animator.SetBool("isDie", true);
        }
        else {
            animator.SetBool("isDamaged", true);
            isDamaged = true;
            playerController.isDamaged = true;
        }

    }
}
