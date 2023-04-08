using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour
{
    private PlayerLife playerLife;
    public GameObject Cure;

    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("adding life");
            playerLife.lifes += 1; // Incrementa la vida en el otro script
            Destroy(Cure); // Destruye el objeto "cure"
        }
    }
}
