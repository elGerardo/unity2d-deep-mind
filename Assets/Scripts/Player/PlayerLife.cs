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

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifes <= 0)
        {
            Destroy(Player);
        }

        if (isDamaged) timer += Time.deltaTime;

        if (timer >= 0.5)
        {
            animator.SetBool("isDamaged", false);
            isDamaged = false;
            playerController.isDamaged = false;
            timer = 0;
        }
    }

    public void TakeHit()
    {
        lifes -= 1;
        animator.SetBool("isDamaged", true);
        isDamaged = true;
        playerController.isDamaged = true;
    }
}
