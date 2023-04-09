using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerWalkingSounds : MonoBehaviour
{
    private float Horizontal;
    private AudioSource audioSource;
    private float walkingTimer = 0;
    [SerializeField] private AudioClip woodSound;
    [SerializeField] private AudioClip metalSound;
    [SerializeField] private AudioClip blockSound;
    [SerializeField] private AudioClip grassSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        walkingTimer += Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (Horizontal != 0.0f && walkingTimer >= 0.5f)
        {

            if (collision.gameObject.tag == "wood")
            {
                audioSource.PlayOneShot(woodSound);
            }

            if (collision.gameObject.tag == "metal")
            {
                audioSource.PlayOneShot(metalSound);
            }

            if (collision.gameObject.tag == "grass")
            {
                audioSource.PlayOneShot(grassSound);
            }

            if (collision.gameObject.tag == "block")
            {
                audioSource.PlayOneShot(blockSound);
            }

            walkingTimer = 0;

        }
    }
}
