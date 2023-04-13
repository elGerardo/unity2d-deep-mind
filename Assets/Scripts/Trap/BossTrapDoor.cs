using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrapDoor : MonoBehaviour
{

    public Transform bossDoor;
    private AudioSource audioSource;
    [SerializeField] private AudioClip doorSound;
    private bool isFallen = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 newPosition = new Vector3(0f, 0f, 0f);
            bossDoor.position = newPosition;
            if(!isFallen) audioSource.PlayOneShot(doorSound);
            isFallen = true;
        }
    }
}
