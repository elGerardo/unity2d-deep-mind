using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public float radiousAtack;
    public Transform controlAtack;

    public SpriteRenderer bossRenderer;
    public Color attackColor;
    public float attackDuration;
    public int lifes;

    private bool canBeDamaged = true;
    private bool playerCanBeDamaged = true;
    private bool playSound = true;
    private Animator Animator;
    private float timer = 0;
    private PlayerLife playerLife;
    public float timeLoop;

    private AudioSource audioSource;
    [SerializeField] private AudioClip atackSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
        playerLife = FindObjectOfType<PlayerLife>();
    }

    public void TakeHit()
    {
        if(canBeDamaged)
        {
            StartCoroutine(TakeHitCoroutine());
            lifes -= 1;
            if(lifes <= 0)
            {
                SceneManager.LoadScene("End");
            }
        }
    }

    void Update()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(controlAtack.position, radiousAtack);

        foreach (Collider2D value in objects)
        {
            if (value.CompareTag("Player"))
            {
                if (playerCanBeDamaged && timer >= 3.5 && timer < 4)
                {
                    playerLife.TakeHit();
                    playerCanBeDamaged = false;
                }
            }
        }


        if (playSound && timer >= 3.5 && timer < 4)
        {
            audioSource.PlayOneShot(atackSound);
            playSound = false;
        }
        if (timer >= 3)
        {
            Animator.SetBool("isAtacking", true);
            canBeDamaged = false;
        }

        if (timer >= 4)
        {
            Animator.SetBool("isAtacking", false);
            playerCanBeDamaged = true;
            canBeDamaged = true;
            playSound = true;
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    IEnumerator TakeHitCoroutine()
    {
        bossRenderer.color = attackColor;
        yield return new WaitForSeconds(attackDuration);
        bossRenderer.color = Color.white;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(controlAtack.position, radiousAtack);
    }
}
